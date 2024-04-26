//record is immutable class
using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.DTOs;

public record class UpdateProjectDto(
    [Required][StringLength(50)]
    string Name, 

    int LanguageId, 

    [Required][StringLength(10)]
    string Level, 
    
    [Required]
    DateOnly CompletionDate
);
