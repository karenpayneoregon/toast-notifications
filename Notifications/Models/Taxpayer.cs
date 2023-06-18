#pragma warning disable CS8618
namespace Notifications.Models;

public class Taxpayer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    // ReSharper disable once InconsistentNaming
    public string SSN { get; set; }
    public string SocialSecurityNumber => SSN.Insert(5, "-").Insert(3, "-");
    public string Pin { get; set; }
    public DateOnly? StartDate { get; set; }
    public int CategoryId { get; set; }

    public override string ToString() => $"{FirstName} {LastName}";


}