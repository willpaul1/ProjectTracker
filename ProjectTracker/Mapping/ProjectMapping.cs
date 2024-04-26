using ProjectTracker.DTOs;
using ProjectTracker.Entities;

namespace ProjectTracker.Mapping;

public static class ProjectMapping
{
    public static Project ToEntity(this CreateProjectDto project)
    {
        return new Project
        {
            Name = project.Name,
            LanguageId = project.LanguageId,
            Level = project.Level,
            CompletionDate = project.CompletionDate
        };
    }

    public static Project ToEntity(this UpdateProjectDto project, int id)
    {
        return new Project()
        {
            Id = id,
            Name = project.Name,
            LanguageId = project.LanguageId,
            Level = project.Level,
            CompletionDate = project.CompletionDate
        };
    }

    public static ProjectSummaryDto ToProjectSummaryDto(this Project project)
    {
        return new(
            project.Id,
            project.Name,
            project.Language!.Name,
            project.Level!,
            project.CompletionDate);
    }

    public static ProjectDetailsDto ToProjectDetailsDto(this Project project)
    {
        return new(
            project.Id,
            project.Name,
            project.LanguageId,
            project.Level!,
            project.CompletionDate);
    }

}
