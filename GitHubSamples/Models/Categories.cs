namespace GitHubSamples.Models;

public class Categories
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}