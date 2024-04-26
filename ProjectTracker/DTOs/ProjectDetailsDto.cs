namespace ProjectTracker.DTOs;

public record class ProjectDetailsDto(
    int Id,
    string Name,
    int LanguageId,
    string Level,
    DateOnly CompletionDate
);