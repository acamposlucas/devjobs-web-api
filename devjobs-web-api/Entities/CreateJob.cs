namespace devjobs_web_api.Entities;

public class CreateJob
{
    public string CompanyId { get; set; }
    public string Position { get; set; }
    public string ContractType { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public GenericModel[] Requirements { get; set; }
    public GenericModel[] Roles { get; set; }
}

public class GenericModel
{
    public string Value { get; set; }
}
