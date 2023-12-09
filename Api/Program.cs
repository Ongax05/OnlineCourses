using Serilog;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;
using API.Extensions;
using API.Helpers;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Set up Serilog for logging
var logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddDbContext<CoursesDbContext>(opt =>
{
    // Configure the database connection
    string connectionString = builder.Configuration.GetConnectionString("SqlServer");
    opt.UseSqlServer(connectionString);
});

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Configure CORS
builder.Services.ConfigureCors();

// Configure Rate Limiting
builder.Services.ConfigureRateLimiting();

// Add application services
builder.Services.AddAplicacionServices();

// Add controllers
builder.Services.AddControllers();

// Configure JWT authentication
builder.Services.AddJwt(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use custom middleware for exception handling
app.UseMiddleware<ExceptionMiddleware>();

// Enable CORS
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// !IMPORTANT: Use authentication middleware before authorization
app.UseAuthentication();

app.UseAuthorization();

// Enable IP rate limiting
app.UseIpRateLimiting();

// Map controllers
app.MapControllers();

app.Run();
