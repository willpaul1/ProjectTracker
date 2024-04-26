using Microsoft.EntityFrameworkCore;
using ProjectTracker.Data;
using ProjectTracker.Mapping;

namespace ProjectTracker.Endpoints;

public static class LanguagesEndpoints
{
    public static RouteGroupBuilder MapLanguagesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("languages");

        // GET /languages
        group.MapGet("/", async (ProjectTrackerContext dbContext) => 
            await dbContext.Languages
                .Select(language => language.ToLanguageDto())
                .AsNoTracking()
                .ToListAsync());

        return group;
    }

}
