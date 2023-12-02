using Serilog;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Percistency.Data;


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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
