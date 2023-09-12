using Microsoft.EntityFrameworkCore;
using ShellTodayNews.Models;
using ShellTodayNews.Service;
using ShellTodayNews.Services;
using ShellTodayNews.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShellTodayNewsDbContext>(
    optionsAction: options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostGreSQLConnString")));





builder.Services.AddScoped<INewsArticle, NewsArticleService>();

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
