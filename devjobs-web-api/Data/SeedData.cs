using devjobs_web_api.Entities;

namespace devjobs_web_api.Data;

internal static class SeedData
{
    internal static Task InitializeAsync(DataContext db)
    {
        Company[] companies =
            [
                new Company
                {
                    Id = 1,
                    Name = "Scoot",
                    Logo = "",
                    LogoBackground = "hsl(36, 87%, 49%)",
                    Website = "https://example.com/scoot",
                    ApplyWebsite = "https://example.com/scoot/apply",
                }
            ];

        Job[] jobs =
            [
                new Job
                {
                    Id = 1,
                    CompanyId = 1,
                    ContractType = "Full Time",
                    Location = "United Kingdom",
                    Description = "Scoot is looking for a Senior Software Engineer passionate about building approachable, innovative and user-first experiences to join our small but growing Engineering team. You will be responsible for building and maintaining front end functionality across all of Scoot’s applications, fostering a growing team of software engineers, and helping drive and maintain best software patterns and practices in our codebase.",
                    PostedAt = DateTime.Now,
                    Position = "Senior Software Engineer",
                }
            ];

        Requirements[] requirements = [
            new Requirements
            {
                Id = 1,
                JobId = 1,
                Content = "he ideal candidate is as passionate about solving challenges through technology. They are well-versed in building proof of concepts from scratch and taking these POCs to production and scale. The right fit will have the engineering experience to build and iterate quickly and is comfortable working with product and design to set the technical strategy and roadmap.",
            },
        ];

        RequirementsItem[] requirementsItems = [
            new RequirementsItem
            {
                Id = 1,
                RequirementsId = 1,
                Description = "5+ years of industry experience in a software engineering role, preferably building a SaaS product. You can demonstrate significant impact that your work has had on the product and/or the team."
            },
            new RequirementsItem
            {
                Id = 2,
                RequirementsId = 1,
                Description = "Experience with scalable distributed systems, both built from scratch as well as on AWS primitives."
            },
            new RequirementsItem
            {
                Id = 3,
                RequirementsId = 1,
                Description = "Extremely data-driven."
            },
            new RequirementsItem
            {
                Id = 4,
                RequirementsId = 1,
                Description = "Ability to debug complex systems."
            },
        ];

        Role[] roles = [
            new Role
            {
                Id = 1,
                JobId = 1,
                Content = "We are looking for a Senior Software Engineer to join as one of our first hires. As we iterate on our MVP, you will have the opportunity to drive the vision and own the build behind our digital experience. You’ll have the support of an experienced technical advisor, a Head of Product, and an external team to work with.",
            }
        ];

        RoleItem[] roleItems = [
            new RoleItem
            {
                Id = 1,
                RoleId = 1,
                Description = "This role is for someone who is excited about the early stage - you’ll be responsible for turning the platform vision into reality through smart, efficient building and testing."
            },
            new RoleItem
            {
                Id = 2,
                RoleId = 1,
                Description = "Translate the product roadmap into engineering requirements and own the engineering roadmap"
            },
            new RoleItem
            {
                Id = 3,
                RoleId = 1,
                Description = "Work with limited resources to test and learn as efficiently as possible, while laying the framework to build a more scalable product over time."
            },
            new RoleItem
            {
                Id = 4,
                RoleId = 1,
                Description = "Collaborate with product, design, and external engineering teammates as needed."
            },
        ];

        db.Companies.AddRange(companies);
        db.Jobs.AddRange(jobs);
        db.Requirements.AddRange(requirements);
        db.RequirementsItems.AddRange(requirementsItems);
        db.Roles.AddRange(roles);
        db.RoleItems.AddRange(roleItems);

        return db.SaveChangesAsync();
    }
}
