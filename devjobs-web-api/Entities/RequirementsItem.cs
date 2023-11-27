using System.Text.Json.Serialization;

namespace devjobs_web_api.Entities;

public class RequirementsItem
{
    public int Id { get; set; }
    [JsonIgnore]
    public Requirements Requirements { get; set; }
    public int RequirementsId { get; set; }
    public string Description { get; set; }
}