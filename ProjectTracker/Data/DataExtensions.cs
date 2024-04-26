﻿using Microsoft.EntityFrameworkCore;

namespace ProjectTracker.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProjectTrackerContext>();
        await dbContext.Database.MigrateAsync();
    }
    
}
