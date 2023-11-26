namespace devjobs_web_api.Entities;

public class RoleItem
{
    public int Id { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
    public string Description { get; set; }
}