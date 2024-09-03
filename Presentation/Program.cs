using Workflows.Models;
using Infrastructure;
using WorkflowCore.Interface;
using DotNetEnv;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Models;
using Domain;
using Application;
using Workflows.Workflows;
using Workflows;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Load environment variables from the .env file
Env.Load();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure()
                .AddDomain()
                .AddApplication()
                .AddWorkflows();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Retrieve the workflow host from the service provider
IWorkflowHost host = app.Services.GetRequiredService<IWorkflowHost>();

// Register the LeaveRequestWorkflow with the workflow host
host.RegisterWorkflow<LeaveRequestWorkflow, LeaveRequestFlowData>();

// Start the workflow host
host.Start();

app.UseHttpsRedirection();

app.MapGet("/hello", () => "Hello World!");

app.MapPost("/workflow-test", async (LeaveRequestFlowData data) =>
{
    string workflowId = await host.StartWorkflow("leave-request-workflow", 1, data);
    return Results.Ok(new { WorkflowId = workflowId });
});

app.MapPost("/leave-request", ([FromBody] LeaveRequest request) =>
{
    // Start the workflow with the provided data
    string workflowId = host.StartWorkflow("leave-request-workflow", 1, new LeaveRequestFlowData
    {
        // Map your LeaveRequest fields to LeaveRequestFlowData here
    }).Result;

    return Results.Ok(new { WorkflowId = workflowId });
});

app.MapPost("/approve-leave-request", async (LeaveRequestDBContext dbContext, [FromBody] ApprovalLeaveRequest approvalRequest) =>
{
    // Fetch the workflow instance
    WorkflowInstance workflowInstance = await host.PersistenceStore.GetWorkflowInstance(approvalRequest.WorkflowId);

    // Cast the workflow data to LeaveRequestFlowData
    LeaveRequestFlowData? workflowData = workflowInstance.Data as LeaveRequestFlowData;

    if (workflowData == null)
    {
        return Results.BadRequest("Invalid workflow data.");
    }

    // Update the workflow data to reflect approval
    workflowData.IsApproved = true;

    // Create a new Approval record
    Approval approval = new Approval
    {
        ApprovalId = Guid.NewGuid(),
        LeaveRequestId = Guid.Parse(approvalRequest.WorkflowId),
        ManagerId = approvalRequest.ManagerId,
        Date = DateTime.UtcNow,
        Decision = "Approved",
        Comments = null
    };

    // Add the approval to the database
    await dbContext.Approvals.AddAsync(approval);
    await dbContext.SaveChangesAsync();

    // Resume the workflow
    await host.PublishEvent("ApprovalEvent", approvalRequest.WorkflowId, workflowInstance.Data);

    return Results.Ok("Leave request approved.");
});

app.MapPost("/cancel-leave-request", async (LeaveRequestDBContext dbContext, IWorkflowHost host, [FromBody] CancelLeaveRequest cancelRequest) =>
{
    // Fetch the workflow instance
    WorkflowInstance workflowInstance = await host.PersistenceStore.GetWorkflowInstance(cancelRequest.WorkflowId);

    if (workflowInstance == null)
    {
        return Results.NotFound("Workflow not found");
    }

    // Cast the workflow data to LeaveRequestFlowData
    LeaveRequestFlowData? workflowData = workflowInstance.Data as LeaveRequestFlowData;

    if (workflowData == null)
    {
        return Results.BadRequest("Invalid workflow data.");
    }

    // Update the workflow data to reflect cancellation
    workflowData.Comments = cancelRequest.Reason;

    // Optionally, create a cancellation record or log the cancellation
    // Here, we assume that cancellations do not need to be separately recorded,
    // but you can create a similar entity to Approval if needed.

    // Terminate the workflow
    await host.TerminateWorkflow(cancelRequest.WorkflowId);

    return Results.Ok("Leave request canceled.");
});



app.Run();
