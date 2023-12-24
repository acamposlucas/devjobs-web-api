using devjobs_web_api.Entities;
using System.Text.Json;

namespace devjobs_web_api.Data;

internal static class SeedData
{
    internal static Task InitializeAsync(DataContext db)
    {
        var json = File.ReadAllText(@"Data/companies.json");
        var companies = JsonSerializer.Deserialize<List<Company>>(json);
        db.Companies.AddRange(companies);

        json = File.ReadAllText(@"Data/contracts.json");
        var contracts = JsonSerializer.Deserialize<List<Contract>>(json);
        db.Contracts.AddRange(contracts);

        db.SaveChangesAsync();

        json = File.ReadAllText(@"Data/jobs.json");
        var jobs = JsonSerializer.Deserialize<List<CreateJob>>(json);

        List<Job> jobList = new List<Job>();
        
        foreach(CreateJob cj in jobs)
        {
            Job job = new Job
            {
                Description = cj.Description,
                Location = cj.Location,
                Position = cj.Position,
            };

            var company = db.Companies.Find(cj.CompanyId);
            if (company is not null)
            {
                job.Company = company;
            }

            var contract = db.Contracts.Find(cj.ContractId);
            if (contract is not null)
            {
                job.Contract = contract;
            }

            Requirements requirements = new Requirements();

            requirements.Content = cj.Requirements.Content;

            foreach (var description in cj.Requirements.Items)
            {
                RequirementsItem item = new RequirementsItem { Description = description };
                requirements.Items.Add(item);
            }

            Role role = new Role();

            role.Content = cj.Roles.Content;

            foreach (var description in cj.Roles.Items)
            {
                RoleItem item = new RoleItem { Description = description };
                role.Items.Add(item);
            }

            job.Requirements = requirements;
            job.Role = role;

            jobList.Add(job);
        }

        db.Jobs.AddRange(jobList);
        
        return db.SaveChangesAsync();
    }
}
