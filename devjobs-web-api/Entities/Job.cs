using System.Text.Json.Serialization;

namespace devjobs_web_api.Entities;

public class Job
{
    public int Id { get; set; }
    public Company Company { get; set; }
    public int CompanyId { get; set; }
    public string Position { get; set; }
    public DateTime PostedAt { get; set; }
    public string ContractType { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public Requirements Requirements { get; set; }
    public int RequirementsId { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
}