namespace ApiDocumentation.Models.Entities;

public class Owner
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public Owner(Guid Id, string FirstName, string lastName, string Mobile)
    {
        this.Id = Id;
        this.FirstName = FirstName;
        LastName = lastName;
        this.Mobile = Mobile;
    }
}