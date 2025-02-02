using Microsoft.EntityFrameworkCore;
using ProyectoBackEnd.Models;
using ProyectoBackEnd.Utilitarios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(
         "MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "http://localhost:49168", "157.100.104.61")
                                .AllowAnyHeader()
                              .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();
builder.Services.AddDbContext<ProyectoSoftwareContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault")));

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors("MyAllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();