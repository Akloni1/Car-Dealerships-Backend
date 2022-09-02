using CarDealerships.Data;
using CarDealerships.Repository;
using CarDealerships.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarDealershipsContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("CarDealershipsContext")));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICarServices, CarServices>();
builder.Services.AddScoped<ICarRepository, CarRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
