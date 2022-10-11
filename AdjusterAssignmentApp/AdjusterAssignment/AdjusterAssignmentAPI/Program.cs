using AdjusterAssignmentAPI.Models;
using AdjusterAssignmentAPI.Repository;
using AdjusterAssignmentAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DbConfiguration>(
    builder.Configuration.GetSection("MongoDbConnection"));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAdjusterAssignmentService, AdjusterAssignmentService>();
builder.Services.AddSingleton<IAdjusterAssignmentRepository, AdjusterAssignmentRepository>();


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
