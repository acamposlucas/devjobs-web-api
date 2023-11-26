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
                },
                new Company
                {
                    Id = 2,
                    Name = "Blogr",
                    Logo = "",
                    LogoBackground = "hsl(12, 79%, 52%)",
                    Website = "https://example.com/blogr",
                    ApplyWebsite = "https://example.com/blogr/apply",
                },
                new Company
                {
                    Id = 3,
                    Name = "Vector",
                    Logo = "",
                    LogoBackground = "hsl(235, 10%, 23%)",
                    Website = "https://example.com/vector",
                    ApplyWebsite = "https://example.com/vector/apply",
                },
                new Company
                {
                    Id = 4,
                    Name = "Office Lite",
                    Logo = "",
                    LogoBackground = "hsl(227, 62%, 48%)",
                    Website = "https://example.com/officelite",
                    ApplyWebsite = "https://example.com/officelite/apply",
                },
                new Company
                {
                    Id = 5,
                    Name = "Pod",
                    Logo = "",
                    LogoBackground = "hsl(216, 46%, 14%)",
                    Website = "https://example.com/pod",
                    ApplyWebsite = "https://example.com/pod/apply",
                },
                new Company
                {
                    Id = 6,
                    Name = "Creative",
                    Logo = "",
                    LogoBackground = "hsl(295, 55%, 21%)",
                    Website = "https://example.com/creative",
                    ApplyWebsite = "https://example.com/creative/apply",
                },
                new Company
                {
                    Id = 7,
                    Name = "Pomodoro",
                    Logo = "",
                    LogoBackground = "hsl(254, 71%, 45%)",
                    Website = "https://example.com/pomodoro",
                    ApplyWebsite = "https://example.com/pomodoro/apply",
                },
                new Company
                {
                    Id = 8,
                    Name = "Maker",
                    Logo = "",
                    LogoBackground = "hsl(218, 58%, 31%)",
                    Website = "https://example.com/maker",
                    ApplyWebsite = "https://example.com/maker/apply",
                },
                new Company
                {
                    Id = 9,
                    Name = "Coffeeroasters",
                    Logo = "",
                    LogoBackground = "hsl(29, 60%, 87%)",
                    Website = "https://example.com/coffeeroasters",
                    ApplyWebsite = "https://example.com/coffeeroasters/apply",
                },
                new Company
                {
                    Id = 10,
                    Name = "Mastercraft",
                    Logo = "",
                    LogoBackground = "hsl(0, 0%, 12%)",
                    Website = "https://example.com/mastercraft",
                    ApplyWebsite = "https://example.com/mastercraft/apply",
                },
                new Company
                {
                    Id = 11,
                    Name = "Crowdfund",
                    Logo = "",
                    LogoBackground = "hsl(157, 57%, 50%)",
                    Website = "https://example.com/crowdfund",
                    ApplyWebsite = "https://example.com/crowdfund/apply",
                },
                new Company
                {
                    Id = 12,
                    Name = "Typemaster",
                    Logo = "",
                    LogoBackground = "hsl(157, 57%, 50%)",
                    Website = "https://example.com/typemaster",
                    ApplyWebsite = "https://example.com/typemaster/apply",
                },
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
                },
                new Job
                {
                    Id = 2,
                    CompanyId = 2,
                    ContractType = "Part Time",
                    Location = "United States",
                    Description = "Blogr is looking for a part-time developer to join our six-strong team of full-stack engineers. Our core development values are strong, static typing and correctness, rigorous automation (in both testing and infrastructure) and everyone having a say.",
                    PostedAt = DateTime.Now.AddHours(-20),
                    Position = "Haskell and PureScript Dev",
                }
            ];

        Requirements[] requirements = [
            new Requirements
            {
                Id = 1,
                JobId = 1,
                Content = "The ideal candidate is as passionate about solving challenges through technology. They are well-versed in building proof of concepts from scratch and taking these POCs to production and scale. The right fit will have the engineering experience to build and iterate quickly and is comfortable working with product and design to set the technical strategy and roadmap.",
            },
            new Requirements
            {
                Id = 2,
                JobId = 2,
                Content = "We are looking to carefully add great developers which care about solving problems & which have been in a relationship with Purescript and/or Haskell for at least 3 years (Not necessarily monogamous though).",
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
            new RequirementsItem
            {
                Id = 5,
                RequirementsId = 2,
                Description = "You have a knack for UI design"
            },
            new RequirementsItem
            {
                Id = 6,
                RequirementsId = 2,
                Description = "Have Haskell or Purescript knowledge/hacking under your belt."
            },
            new RequirementsItem
            {
                Id = 7,
                RequirementsId = 2,
                Description = "An experienced engineer familiar with automated testing and deployment."
            },
            new RequirementsItem
            {
                Id = 8,
                RequirementsId = 2,
                Description = "Experienced with functional programming and domain-driven design or simply interested and capable of learning on the job."
            },
        ];

        Role[] roles = [
            new Role
            {
                Id = 1,
                JobId = 1,
                Content = "We are looking for a Senior Software Engineer to join as one of our first hires. As we iterate on our MVP, you will have the opportunity to drive the vision and own the build behind our digital experience. You’ll have the support of an experienced technical advisor, a Head of Product, and an external team to work with.",
            },
            new Role
            {
                Id = 2,
                JobId = 2,
                Content = "The role is more frontend-focused where you will be tasked to build browser-based UIs for Haskell applications.",
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
            new RoleItem
            {
                Id = 5,
                RoleId = 2,
                Description = "Build up our tech stack around Haskell and introduce best practices"
            },
            new RoleItem
            {
                Id = 6,
                RoleId = 2,
                Description = "Contribute to the design of our conversational engine and the architecture supporting it"
            },
            new RoleItem
            {
                Id = 7,
                RoleId = 2,
                Description = "Design new UIs, working closely with users, stakeholders and the backend team."
            },
            new RoleItem
            {
                Id = 8,
                RoleId = 2,
                Description = "Maximize robustness, performance, and scalability of solutions"
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
