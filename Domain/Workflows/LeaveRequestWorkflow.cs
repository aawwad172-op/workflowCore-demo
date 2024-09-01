using Domain.LeaveSteps;
using Domain.Models;
using WorkflowCore.Interface;

namespace Domain.Workflows
{
    /// <summary>
    /// Defines the leave request workflow, which orchestrates the process of handling
    /// an employee's leave request from submission through approval or rejection and finalization.
    /// This class implements the IWorkflow interface, which is part of the WorkflowCore library.
    /// </summary>
    public class LeaveRequestWorkflow : IWorkflow<LeaveRequestFlowData>
    {
        /// <summary>
        /// Gets the unique identifier for this workflow. This is used to distinguish this workflow from others.
        /// </summary>
        public string Id => "leave-request-workflow";

        /// <summary>
        /// Gets the version number of the workflow. Versioning allows you to manage changes to the workflow over time.
        /// </summary>
        public int Version => 1;

        /// <summary>
        /// Builds the workflow, defining the sequence of steps that the workflow will execute.
        /// This method specifies the order of execution, branching logic, and the conditions under which steps are executed.
        /// </summary>
        /// <param name="builder">The workflow builder used to construct the workflow.
        /// It provides methods to define steps, control flow, and set up data handling within the workflow.</param>
        public void Build(IWorkflowBuilder<LeaveRequestFlowData> builder)
        {
            builder
                // Start the workflow with the SendLeaveRequest step
                .StartWith<SendLeaveRequest>()
                // Proceed to the WaitForApprovalStep, which waits for an approval decision
                .Then<WaitForApprovalStep>()
                // Execute the ApprovalDecisionStep to determine if the request is approved or rejected
                .Then<ApprovalDecisionStep>()
                // Branch the workflow based on whether the leave request was approved
                .If(data => data.IsApproved)
                    .Do(then => then
                        // If approved, notify the employee and update the leave records
                        .StartWith<NotifyEmployeeStep>()
                        .Then<UpdateLeaveRecordsStep>())
                // Branch for handling a rejected leave request
                .If(data => !data.IsApproved)
                    .Do(then => then
                        // Notify the employee of the rejection
                        .StartWith<NotifyEmployeeStep>()) // Notify of rejection
                                                          // Finalize the workflow after handling the approval or rejection
                .Then<FinalizeWorkflowStep>();
        }

        // The commented-out Build method below is a placeholder for another potential implementation
        // with a generic object type. It has been left here as a stub but is not implemented.
        // public void Build(IWorkflowBuilder<object> builder)
        // {
        //     throw new NotImplementedException();
        // }
    }
}

