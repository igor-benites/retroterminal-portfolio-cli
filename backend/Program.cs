using AiChatbotAPI.Services;
using AiChatbotAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

// Retrieve the DeepSeek API key from the .env file
var apiKey = Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY");

if (string.IsNullOrEmpty(apiKey))
{
    throw new ArgumentException("API Key is missing");
}

// Load the curriculum JSON from the file
var curriculumJson = File.ReadAllText("curriculum.json");
var curriculumData = JsonConvert.DeserializeObject<Dictionary<string, object>>(curriculumJson);

// Register the ChatService with the loaded curriculum data
builder.Services.AddSingleton<ChatService>(sp =>
{
    var httpClient = sp.GetRequiredService<HttpClient>();
    return new ChatService(httpClient, apiKey, curriculumData);
});

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI();  
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
