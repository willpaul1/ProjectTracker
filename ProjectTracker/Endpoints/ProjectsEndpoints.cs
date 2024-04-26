using ProjectTracker.DTOs;
using MinimalApis;
using ProjectTracker.Data;
using ProjectTracker.Entities;
using ProjectTracker.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ProjectTracker.Endpoints;

public static class ProjectsEndpoints
{
    const string GetProjectEndpointName = "GetProject";

    public static RouteGroupBuilder MapProjectsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("projects").WithParameterValidation();

        // GET /projects
        group.MapGet("/", async (ProjectTrackerContext dbContext) => 
        {
            
            await Task.Delay(3000); // Simulate a slow endpoint
            return await dbContext.Projects
                .Include(project => project.Language)
                .Select(project => project.ToProjectSummaryDto())
                .AsNoTracking()
                .ToListAsync();
        });

        // GET /projects/1
        group.MapGet("/{id}", async (int id, ProjectTrackerContext dbContext) => 
        {
            Project? project = await dbContext.Projects.FindAsync(id);

            return project is null ? 
            Results.NotFound() : Results.Ok(project.ToProjectDetailsDto());
        })

        .WithName(GetProjectEndpointName);

        // POST /projects

        group.MapPost("/", async (CreateProjectDto newProject, ProjectTrackerContext dbContext) => 
        {
            Project project = newProject.ToEntity();

            dbContext.Projects.Add(project);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(GetProjectEndpointName, new { id = project.Id }, project.ToProjectDetailsDto());
            
        });

        // PUT /projects/1
        group.MapPut("/{id}", async (int id, UpdateProjectDto updatedProject, ProjectTrackerContext dbContext) => 
        {
            var existingProject = await dbContext.Projects.FindAsync(id);

            if (existingProject is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingProject).CurrentValues.SetValues(updatedProject.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
    
        });

        // DELETE /projects/1
        group.MapDelete("/{id}", async (int id, ProjectTrackerContext dbContext) => 
        {
            await dbContext.Projects
                    .Where(project => project.Id == id)
                    .ExecuteDeleteAsync();

            return Results.NoContent();
        });
        

        return group;
    }    
}
