using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{  
    options.Cookie.Name = ".Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton(ServiceProvider =>
{
    return new SqliteConnection("Data source=one-month.db");
});

var app = builder.Build();
app.UseSession();

var connection = app.Services.GetRequiredService<SqliteConnection>();
await DatabaseSeeder.CreateTables(connection);

app.MapGet("/", () => "Hello World!");

app.Run();
