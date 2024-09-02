# Leave Request Workflow Demo with WorkflowCore

## Overview

This project is a demonstration of a leave request workflow implemented using [WorkflowCore](https://github.com/danielgerlag/workflow-core?tab=readme-ov-file) in a .NET 8 application. The workflow handles the process of submitting a leave request, waiting for approval, notifying the employee, and updating leave records. The project showcases how to set up WorkflowCore, define a workflow, and expose an API endpoint to trigger the workflow.

## Table of Contents

- [Introduction to WorkflowCore](#introduction-to-workflowcore)
- [Project Structure](#project-structure)
- [Setup and Installation](#setup-and-installation)
- [Workflow Details](#workflow-details)
- [Endpoints](#endpoints)
- [Running the Application](#running-the-application)
- [Official Documentation](#official-documentation)
- [Repository Link](#repository-link)

## Introduction to WorkflowCore

WorkflowCore is a lightweight workflow engine targeting .NET Standard. It provides a framework for creating long-running processes with persistent state, event-driven execution, and a modular design.

Key features of WorkflowCore include:
- Persistence providers for databases and in-memory storage.
- Event-driven workflow execution.
- Thread-safe workflow execution with support for multiple concurrent workflows.
- Easy-to-define workflows using a builder pattern.

For more details, visit the official documentation: [WorkflowCore Documentation](https://workflow-core.readthedocs.io/en/latest/getting-started/).

## Project Structure

The project is structured as follows:

- **Domain**: Contains the workflow steps (`Steps`) and the data model (`Models`) used in the workflow.
- **Presentation**: The main project that hosts the web API, including the `Program.cs` where the workflow host is configured and the API endpoint is exposed.

### Key Components:

- **`LeaveRequestWorkflow`**: The main workflow that orchestrates the leave request process.
- **`LeaveRequestFlowData`**: The data model that holds the state and information passed through the workflow.
- **Steps**:
  - **`SendLeaveRequest`**: Sends the leave request.
  - **`WaitForApprovalStep`**: Waits for an approval decision.
  - **`ApprovalDecisionStep`**: Processes the approval decision.
  - **`NotifyEmployeeStep`**: Notifies the employee of the decision.
  - **`UpdateLeaveRecordsStep`**: Updates the employee's leave records.
  - **`FinalizeWorkflowStep`**: Finalizes the workflow.

## Setup and Installation

1. **Clone the Repository:**

   ```bash
   git clone [Your_Repository_URL]
   ```

2. **Navigate to the Project Directory:**

   ```bash
   cd [Project_Directory]
   ```

3. **Restore the Dependencies:**

   ```bash
   dotnet restore
   ```

4. **Run the Application:**

   ```bash
   dotnet run
   ```

## Workflow Details

### Leave Request Workflow

The `LeaveRequestWorkflow` consists of several steps that simulate the leave request process:

1. **SendLeaveRequest**: Sends the leave request.
2. **WaitForApprovalStep**: Pauses the workflow to wait for an approval decision.
3. **ApprovalDecisionStep**: Determines if the leave is approved or rejected.
4. **NotifyEmployeeStep**: Notifies the employee about the decision.
5. **UpdateLeaveRecordsStep**: Updates the leave records if the request is approved.
6. **FinalizeWorkflowStep**: Finalizes the workflow.

### Program.cs Configuration

In the `Program.cs`, WorkflowCore is configured and the workflow is registered with the workflow host. An API endpoint is also exposed to start the workflow.

```csharp
// Register WorkflowCore services
builder.Services.AddWorkflow();

// Build the service provider to retrieve registered services
var serviceProvider = app.Services;

// Retrieve the workflow host from the service provider
var host = serviceProvider.GetRequiredService<IWorkflowHost>();

// Register the LeaveRequestWorkflow with the workflow host
host.RegisterWorkflow<LeaveRequestWorkflow, LeaveRequestFlowData>();

// Start the workflow host
host.Start();

// Endpoint to start the leave request workflow
app.MapPost("/start-leave-request", async (LeaveRequestFlowData data) =>
{
    var workflowId = await host.StartWorkflow("leave-request-workflow", 1, data);
    return Results.Ok(new { WorkflowId = workflowId });
});

app.Run();
```

## Endpoints

### Start Leave Request Workflow

- **POST** `/start-leave-request`
  
  Starts the `LeaveRequestWorkflow` with the provided data.

  **Request Body:**
  ```json
  {
      "EmployeeId": "12345",
      "LeaveDays": 5,
      "IsApproved": false,
      "Comments": "Requesting 5 days of leave."
  }
  ```

  **Response:**
  ```json
  {
      "WorkflowId": "your-workflow-id"
  }
  ```

## Running the Application

1. **Start the Application**:
   - Run the application using the `dotnet run` command.

2. **Use Swagger UI**:
   - Navigate to `https://localhost:5001/swagger` to view and test the API using Swagger UI.

3. **Start a Workflow**:
   - Use a tool like Postman or Swagger UI to send a POST request to `/start-leave-request` with the required data.

## Official Documentation

For more detailed information about WorkflowCore, visit the official documentation: [WorkflowCore Documentation](https://workflow-core.readthedocs.io/en/latest/getting-started/).

## Repository Link

To explore the WorkflowCore repository, visit: [WorkflowCore GitHub Repository](https://github.com/danielgerlag/workflow-core?tab=readme-ov-file).
