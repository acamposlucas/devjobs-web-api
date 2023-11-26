using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
