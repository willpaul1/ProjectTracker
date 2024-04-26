//record is immutable class

namespace ProjectTracker.DTOs;

public record class ProjectSummaryDto(
    int Id, 
    string Name, 
    string Language, 
    string Level, 
    DateOnly CompletionDate
);