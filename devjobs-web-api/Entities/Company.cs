using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace devjobs_web_api.Entities;

[Table("Companies")]
public class Company
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Logo { get; set; }
    [Required]
    public string LogoBackground { get; set; }
    [Required]
    public string Website { get; set; }
    [Required]
    public string ApplyWebsite { get; set; }

    [JsonIgnore]
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
