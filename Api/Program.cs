using Serilog;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;
using API.Extensions;
using API.Helpers;
using AspNetCoreRateLimit;


var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
// Add services to the container.
builder.Logging.AddSerilog(logger);

builder.Services.AddDbContext<CoursesDbContext>(opt=>{
    string connectionString = builder.Configuration.GetConnectionString("SqlServer");
    opt.UseSqlServer(connectionString);
});
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAplicacionServices();
builder.Services.AddControllers();
builder.Services.AddJwt(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseIpRateLimiting();

app.Run();

app.MapControllers();

app.Run();
