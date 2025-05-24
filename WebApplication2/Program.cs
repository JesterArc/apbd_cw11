using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddDbContext<DatabaseContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
