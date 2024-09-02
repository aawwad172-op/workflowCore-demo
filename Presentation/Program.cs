using Domain.Models;
using Domain.Workflows;
using Infrastructure;
using WorkflowCore.Interface;
using Domain.Interfaces;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
Env.Load();

// Get the connection string from the environment variable
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

// if (string.IsNullOrEmpty(connectionString))
// {
//     throw new InvalidOperationException("The connection string was not found in the environment variables.");
// }

// Register WorkflowCore services
builder.Services.AddWorkflow(x => x.UsePostgreSQL(@"Host=localhost;Database=HRS-workflows;Username=postgres;Password=admin;", true, true));

// Register the DbContext with the connection string from the environment
builder.Services.AddDbContext<LeaveRequestDBContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Retrieve the workflow host from the service provider
var host = app.Services.GetRequiredService<IWorkflowHost>();

// Register the LeaveRequestWorkflow with the workflow host
host.RegisterWorkflow<LeaveRequestWorkflow, LeaveRequestFlowData>();

// Start the workflow host
host.Start();

app.UseHttpsRedirection();

app.MapGet("/hello", () => "Hello World!");

app.MapPost("/workflow-test", async (LeaveRequestFlowData data) =>
{
    var workflowId = await host.StartWorkflow("leave-request-workflow", 1, data);
    return Results.Ok(new { WorkflowId = workflowId });
});

app.MapPost("/leave-request", ([FromBody] LeaveRequest request) =>
{
    // Start the workflow with the provided data
    var workflowId = host.StartWorkflow("leave-request-workflow", 1, new LeaveRequestFlowData
    {
        // Map your LeaveRequest fields to LeaveRequestFlowData here
    }).Result;

    return Results.Ok(new { WorkflowId = workflowId });
});

app.Run();
