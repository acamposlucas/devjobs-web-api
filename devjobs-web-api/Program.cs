using devjobs_web_api.Data;
using devjobs_web_api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", builder =>
    {
        builder
            .WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data Source=devjobs.db");
});

var app = builder.Build();

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
    await db.Database.EnsureDeletedAsync();
    if (await db.Database.EnsureCreatedAsync())
    {
        await SeedData.InitializeAsync(db);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
          "Origin, X-Requested-With, Content-Type, Accept");
    }
});
app.UseCors("corsapp");

app.MapGet("/companies", async (DataContext context) => await context.Companies.ToListAsync());

app.MapGet("/jobs", async (DataContext context) =>
{
    var jobs = await context.Jobs
        .Include(j => j.Company)
        .Include(j => j.Contract)
        .Include(j => j.Requirements).ThenInclude(r => r.Items)
        .Include(j => j.Role).ThenInclude(r => r.Items)
        .ToListAsync();

    return jobs;
});

app.MapGet("/jobs/{id:int}", async (DataContext context, int id) =>
{
    var job = await context.Jobs
        .Include(j => j.Company)
        .Include(j => j.Contract)
        .Include(j => j.Requirements).ThenInclude(r => r.Items)
        .Include(j => j.Role).ThenInclude(r => r.Items)
        .Where(j => j.Id == id)
        .FirstOrDefaultAsync();

    return job;
});

app.MapGet("jobs/summaries", async (DataContext context) =>
{
    var summaries = await context.Jobs
        .Include(j => j.Company)
        .Include(j => j.Contract)
        .OrderByDescending(j => j.PostedAt)
        .ToListAsync();

    var result = from job in summaries select new { Id = job.Id, Company = job.Company.Name, PostedAt = job.PostedAt, Position = job.Position, Contract = job.Contract, Location = job.Location, BackgroundColor = job.Company.LogoBackground };

    return result;
});

app.MapPost("/jobs", async (CreateJob request, DataContext context) =>
{
    Job job = new Job
    {
        Description = request.Description,
        Location = request.Location,
        Position = request.Position,
        Requirements = new Requirements(),
        Role = new Role()
    };

    var company = context.Companies.Find(request.CompanyId);
    if (company is not null)
    {
        job.Company = company;
    }

    var contract = context.Contracts.Find(request.ContractId);
    if (contract is not null)
    {
        job.Contract = contract;
    }

    job.Requirements.Content = request.Requirements.Content;

    foreach (var description in request.Requirements.Items)
    {
        job.Requirements.Items.Add(new RequirementsItem { Description = description });
    }

    job.Role.Content = request.Roles.Content;

    foreach (var description in request.Roles.Items)
    {
        job.Role.Items.Add(new RoleItem { Description = description });
    }

    context.Jobs.Add(job);

    await context.SaveChangesAsync();

    return job;
});

app.MapGet("contracts", async (DataContext context) =>
{
    return await context.Contracts.OrderBy(c => c.Type).ToListAsync();
});

app.Run();
