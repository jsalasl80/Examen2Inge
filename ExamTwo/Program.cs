using ExamTwo.Controllers;
using ExamTwo.Repository;
using ExamTwo.Repository.Interface;
using ExamTwo.Business;
using ExamTwo.Business.Interface;
using ExamTwo.Business.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICoffeeRepository, CoffeeRepository>();

builder.Services.AddScoped<ICoffeeService, CoffeeService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Database>();


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
