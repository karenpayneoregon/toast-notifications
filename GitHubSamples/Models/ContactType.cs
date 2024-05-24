namespace GitHubSamples.Models;

public class ContactType
{
    public int Id { get; set; }
    public string Title { get; set; }
    public override string ToString() => Title;
}