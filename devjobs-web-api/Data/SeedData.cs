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
                    Name = "Scoot",
                    Logo = "",
                    LogoBackground = "hsl(36, 87%, 49%)",
                    Website = "https://example.com/scoot",
                    ApplyWebsite = "https://example.com/scoot/apply",
                },
                new Company
                {
                    Name = "Blogr",
                    Logo = "",
                    LogoBackground = "hsl(12, 79%, 52%)",
                    Website = "https://example.com/blogr",
                    ApplyWebsite = "https://example.com/blogr/apply",
                },
                new Company
                {
                    Name = "Vector",
                    Logo = "",
                    LogoBackground = "hsl(235, 10%, 23%)",
                    Website = "https://example.com/vector",
                    ApplyWebsite = "https://example.com/vector/apply",
                },
                new Company
                {
                    Name = "Office Lite",
                    Logo = "",
                    LogoBackground = "hsl(227, 62%, 48%)",
                    Website = "https://example.com/officelite",
                    ApplyWebsite = "https://example.com/officelite/apply",
                },
                new Company
                {
                    Name = "Pod",
                    Logo = "",
                    LogoBackground = "hsl(216, 46%, 14%)",
                    Website = "https://example.com/pod",
                    ApplyWebsite = "https://example.com/pod/apply",
                },
                new Company
                {
                    Name = "Creative",
                    Logo = "",
                    LogoBackground = "hsl(295, 55%, 21%)",
                    Website = "https://example.com/creative",
                    ApplyWebsite = "https://example.com/creative/apply",
                },
                new Company
                {
                    Name = "Pomodoro",
                    Logo = "",
                    LogoBackground = "hsl(254, 71%, 45%)",
                    Website = "https://example.com/pomodoro",
                    ApplyWebsite = "https://example.com/pomodoro/apply",
                },
                new Company
                {
                    Name = "Maker",
                    Logo = "",
                    LogoBackground = "hsl(218, 58%, 31%)",
                    Website = "https://example.com/maker",
                    ApplyWebsite = "https://example.com/maker/apply",
                },
                new Company
                {
                    Name = "Coffeeroasters",
                    Logo = "",
                    LogoBackground = "hsl(29, 60%, 87%)",
                    Website = "https://example.com/coffeeroasters",
                    ApplyWebsite = "https://example.com/coffeeroasters/apply",
                },
                new Company
                {
                    Name = "Mastercraft",
                    Logo = "",
                    LogoBackground = "hsl(0, 0%, 12%)",
                    Website = "https://example.com/mastercraft",
                    ApplyWebsite = "https://example.com/mastercraft/apply",
                },
                new Company
                {
                    Name = "Crowdfund",
                    Logo = "",
                    LogoBackground = "hsl(157, 57%, 50%)",
                    Website = "https://example.com/crowdfund",
                    ApplyWebsite = "https://example.com/crowdfund/apply",
                },
                new Company
                {
                    Name = "Typemaster",
                    Logo = "",
                    LogoBackground = "hsl(157, 57%, 50%)",
                    Website = "https://example.com/typemaster",
                    ApplyWebsite = "https://example.com/typemaster/apply",
                },
            ];

        Contract[] contracts = [
            new Contract() { Type = "Full Time"},    
            new Contract() { Type = "Part Time"},    
            new Contract() { Type = "Remote"},
        ];

        db.Companies.AddRange(companies);
        db.Contracts.AddRange(contracts);

        return db.SaveChangesAsync();
    }
}
