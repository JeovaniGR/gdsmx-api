using gdsmx_back_netcoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using gdsmx_back_netcoreAPI.BL.Interfaces;
using gdsmx_back_netcoreAPI.BL.Implementation;
using gdsmx_back_netcoreAPI.Data.Repositories;
using gdsmx_back_netcoreAPI.Data.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<sdgmxdemosqldbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionStrig"), providerOptions => providerOptions.EnableRetryOnFailure()));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IBLEmployee, BLEmployee>();
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
