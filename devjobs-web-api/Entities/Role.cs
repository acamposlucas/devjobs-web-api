namespace devjobs_web_api.Entities;

public class Role
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; }
    public string Content { get; set; }
    public List<RoleItem> Items { get; set; }
}