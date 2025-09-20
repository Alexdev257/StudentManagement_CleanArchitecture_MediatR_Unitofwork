using MediatR;
using Microsoft.EntityFrameworkCore;
using SM.Application.CQRS.Command;
using SM.Application.CQRS.Hanlders;
using SM.Application.Interface.IRepo;
using SM.Infrastructure.Data;
using SM.Infrastructure.DependencyInjection;
using SM.Infrastructure.Implements;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(CreateStudentCommand).Assembly);
// Add services to the container.

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
