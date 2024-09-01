using Domain.Models;
using Domain.Workflows;
using WorkflowCore.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register WorkflowCore services
builder.Services.AddWorkflow();
// This line registers the core WorkflowCore services in the dependency injection container.
// WorkflowCore handles the execution of workflows, including managing their state and coordinating the execution of workflow steps.

var app = builder.Build();

// Build the service provider to retrieve registered services
var serviceProvider = app.Services;
// Here, the service provider is built, which is used to retrieve instances of registered services, 
// including the WorkflowCore host and any workflows you may have defined.


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Retrieve the workflow host from the service provider
var host = serviceProvider.GetRequiredService<IWorkflowHost>();
// The workflow host is the core service that manages the execution of workflows. 
// It polls for workflows that are ready to run, executes them, and manages their persistence.
// This line retrieves the workflow host from the service provider, ensuring it is available to start and manage workflows.

// Register the LeaveRequestWorkflow with the workflow host
host.RegisterWorkflow<LeaveRequestWorkflow, LeaveRequestFlowData>();
// This line registers the specific workflow (LeaveRequestWorkflow) with the workflow host. 
// Registration is necessary so that the workflow host knows which workflows it is responsible for managing.
// The workflow is registered with a specific data model (LeaveRequestFlowData) that holds the state and data for the workflow.

// Start the workflow host
host.Start();
// This line starts the workflow host. Starting the host initializes the necessary threads and timers that 
// handle workflow execution. It is crucial to start the host to begin processing workflows and their steps.

// Ensure the application uses HTTPS for secure communication
app.UseHttpsRedirection();

app.MapGet("/hello", () => "Hello World!");

app.MapPost("/start-leave-request", async (LeaveRequestFlowData data) =>
{
    // Start the workflow with the provided data
    var workflowId = await host.StartWorkflow("leave-request-workflow", 1, data);

    // This endpoint initiates the LeaveRequestWorkflow. When a POST request is made to /start-leave-request,
    // the workflow is started with the provided data. The workflow ID is returned, which can be used to track
    // the workflow's progress or interact with it further.

    return Results.Ok(new { WorkflowId = workflowId });
});

app.Run();
// This line starts the web application and begins listening for incoming HTTP requests.
// The application will keep running until it is explicitly stopped.
