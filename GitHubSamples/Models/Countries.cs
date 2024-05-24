namespace GitHubSamples.Models;

public class Countries
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}