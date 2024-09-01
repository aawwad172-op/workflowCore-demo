using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Domain.LeaveSteps
{
    /// <summary>
    /// Represents a step in the workflow that sends a leave request.
    /// Inherits from the WorkflowCore StepBody class.
    /// </summary>
    public class SendLeaveRequest : StepBody
    {
        /// <summary>
        /// Executes the logic associated with this step.
        /// This method is called when the workflow reaches the SendLeaveRequest step.
        /// </summary>
        /// <param name="context">Provides context about the workflow execution,
        /// including data and the current state of the workflow.</param>
        /// <returns>An ExecutionResult indicating the next action to take.
        /// In this case, it moves the workflow to the next step.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // Log the execution of this step (for demonstration purposes)
            Console.WriteLine("SendLeaveRequest: Sending leave request...");

            // TODO: Implement the logic to send a leave request here.
            // For example, you could call an external service, update a database, etc.
            // Example: LeaveRequestService.SendRequest();
            // Example: LeaveRequestRepository.UpdateStatus("Request Sent");

            // Return ExecutionResult.Next() to indicate that the step completed successfully
            // and the workflow should proceed to the next step.
            return ExecutionResult.Next();
        }
    }
}
