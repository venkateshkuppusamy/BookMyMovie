using System.Data;
using BookMyMovie.TenantMgmt.API.Business;
using BookMyMovie.TenantMgmt.API.Business.Domain;
using BookMyMovie.TenantMgmt.API.Business.Interfaces;
using BookMyMovie.TenantMgmt.API.Repositories;
using BookMyMovie.TenantMgmt.API.Repositories.Entities;
using BookMyMovie.TenantMgmt.API.Repositories.Interfaces;
using Dapper.FluentMap;
using Microsoft.Data.SqlClient;
using BookMyMovie.TenantMgmt.API.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 🔹 Retrieve the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("MovieConnectionString");

// 🔹 Register IDbConnection as a Scoped Service
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
// Register AutoMapper
builder.Services.AddAutoMapper(typeof(TenantProfile));
builder.Services.AddScoped<IService<Tenant>, TenantService>();
builder.Services.AddScoped<IRepository<TenantEntity>, TenantRepository>();

FluentMapper.Initialize(config =>
{
    config.AddMap(new TenantEntityMap());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
