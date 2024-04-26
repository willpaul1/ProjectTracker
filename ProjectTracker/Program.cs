using ProjectTracker.Data;
using ProjectTracker.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProjectTracker");

//scoped lifetime
builder.Services.AddSqlite<ProjectTrackerContext>(connectionString);

var app = builder.Build();

app.MapProjectsEndpoints();
app.MapLanguagesEndpoints();

await app.MigrateDbAsync();

app.Run();
