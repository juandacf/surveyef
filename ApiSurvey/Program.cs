using Infrastructure.data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TallerSurveyDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseNpgsql(connectionString);
});


builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

