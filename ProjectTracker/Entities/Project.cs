namespace ProjectTracker.Entities;

public class Project
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int LanguageId { get; set; }

    public Language? Language { get; set; }

    public string? Level { get; set; }

    public DateOnly CompletionDate { get; set; }

}
