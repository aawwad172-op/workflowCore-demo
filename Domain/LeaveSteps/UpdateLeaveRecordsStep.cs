using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Domain.LeaveSteps
{
    /// <summary>
    /// Represents a step in the workflow that updates the leave records after a leave request has been processed.
    /// This step typically occurs after the leave request has been approved and is responsible for updating
    /// the employee's leave balance or other related records in the system.
    /// </summary>
    public class UpdateLeaveRecordsStep : StepBody
    {
        /// <summary>
        /// Executes the logic associated with this step.
        /// This method is called when the workflow reaches the UpdateLeaveRecordsStep.
        /// </summary>
        /// <param name="context">Provides context about the workflow execution,
        /// including data and the current state of the workflow.</param>
        /// <returns>An ExecutionResult indicating the next action to take.
        /// In this case, it moves the workflow to the next step after updating the leave records.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // Log the execution of this step to the console for tracking purposes
            Console.WriteLine("UpdateLeaveRecordsStep: Updating leave records...");

            // TODO: Implement logic to update leave records in the system.
            // This could involve calling a service to update the database with the new leave balance.
            // Example: LeaveRecordService.Update(employeeId, approvedLeaveDays);

            // Return ExecutionResult.Next() to indicate that the step completed successfully
            // and the workflow should proceed to the next step.
            return ExecutionResult.Next();
        }
    }
}
