using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

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
