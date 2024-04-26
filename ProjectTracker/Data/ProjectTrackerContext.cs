using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Entities;

namespace ProjectTracker.Data;

public class ProjectTrackerContext(DbContextOptions<ProjectTrackerContext> options) 
    : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Language> Languages => Set<Language>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>().HasData(
            new { Id = 1, Name = "C#" },
            new { Id = 2, Name = "ASP.NET Web" },
            new { Id = 3, Name = ".NET Maui" },
            new { Id = 4, Name = "Python" },
            new { Id = 5, Name = "HTML/CSS/Javascript" }
        );
    }
}
    
