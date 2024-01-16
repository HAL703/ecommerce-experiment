using Microsoft.EntityFrameworkCore;
using ecommerce_experiment.Server;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var a = builder.Services.AddDbContext<UserContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ecommerce")));

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
