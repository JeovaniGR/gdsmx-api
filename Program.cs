using gdsmx_back_netcoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using gdsmx_back_netcoreAPI.Data;
using gdsmx_back_netcoreAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<sdgmxdemosqldbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionStrig")));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
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
