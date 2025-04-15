// Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("UserManagementDB"));

builder.Services.AddControllers();

var app = builder.Build();

// Use Logging Middleware
app.UseMiddleware<LoggingMiddleware>();

// Use Authentication Middleware
app.UseMiddleware<AuthenticationMiddleware>();

app.UseRouting();
app.MapControllers();

app.Run();
