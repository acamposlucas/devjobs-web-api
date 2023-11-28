using devjobs_web_api.Data;
using devjobs_web_api.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.UseStaticFiles();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/companies", async (DataContext context) => await context.Companies.ToListAsync());

app.MapGet("/jobs", async (DataContext context) =>
{
    var jobs = await context.Jobs
        .Include(j => j.Company)
        .Include(j => j.Requirements).ThenInclude(r => r.Items)
        .Include(j => j.Role).ThenInclude(r => r.Items)
        .ToListAsync();

    return jobs;
});

app.MapGet("jobs/summaries", async (DataContext context) =>
{
    var summaries = await context.Jobs
        .Include(j => j.Company)
        .OrderBy(j => j.PostedAt)
        .ToListAsync();

    var result = from job in summaries select new { Company = job.Company.Name, PostedAt = job.PostedAt, Position = job.Position, Contract = job.ContractType, Location = job.Location, BackgroundColor = job.Company.LogoBackground };

    return result;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
