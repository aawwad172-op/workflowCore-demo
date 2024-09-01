using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Domain.LeaveSteps
{
    /// <summary>
    /// Represents a step in the leave request workflow that handles waiting for an approval decision.
    /// This step is crucial in workflows where an external decision or approval process is required before proceeding.
    /// </summary>
    public class WaitForApprovalStep : StepBody
    {
        /// <summary>
        /// Executes the logic associated with this step.
        /// This method is called when the workflow reaches the WaitForApprovalStep,
        /// and it handles the logic needed to wait for an approval decision.
        /// </summary>
        /// <param name="context">Provides context about the workflow execution,
        /// including data and the current state of the workflow.</param>
        /// <returns>An ExecutionResult that indicates whether the workflow should proceed or pause
        /// until the approval decision is made.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // Log the execution of this step to the console for tracking purposes
            Console.WriteLine("WaitForApprovalStep: Waiting for approval...");

            // TODO: Implement logic to wait for an approval decision.
            // This might involve checking a status, waiting for a signal, or polling a service.
            // If the workflow needs to pause here until the approval is received, return ExecutionResult.Persist().

            // Return ExecutionResult.Next() to indicate that the step completed successfully
            // and the workflow should proceed to the next step.
            return ExecutionResult.Next();
        }
    }
}
