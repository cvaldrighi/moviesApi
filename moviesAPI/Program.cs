using Microsoft.EntityFrameworkCore;
using moviesAPI.Data;
using moviesAPI.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connection = builder.Configuration["ConnectionStrings:MovieConnection"];

builder.Services.AddDbContext<MovieContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(
        connection,
        new MySqlServerVersion(
            new Version(8, 0, 29)
      
)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<AddressService, AddressService>();
builder.Services.AddScoped<ManagerService, ManagerService>();
builder.Services.AddScoped<CinemaService, CinemaService>();
builder.Services.AddScoped<MovieService, MovieService>();
builder.Services.AddScoped<SessionService, SessionService>();
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
