using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Domain.LeaveSteps
{
    /// <summary>
    /// Represents the final step in the leave request workflow.
    /// The purpose of this step is to perform any necessary finalization tasks once all other steps have been completed.
    /// This could include logging the completion of the workflow, updating status flags, or any other cleanup operations.
    /// </summary>
    public class FinalizeWorkflowStep : StepBody
    {
        /// <summary>
        /// Executes the logic associated with finalizing the workflow.
        /// This method is called when the workflow reaches the FinalizeWorkflowStep, typically as the last step in the process.
        /// </summary>
        /// <param name="context">Provides context about the workflow execution,
        /// including data and the current state of the workflow.</param>
        /// <returns>An ExecutionResult indicating that the workflow has been finalized
        /// and should either complete or move to any final cleanup steps.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // Log the execution of this step to the console for tracking purposes
            Console.WriteLine("FinalizeWorkflowStep: Finalizing the leave request workflow...");

            // TODO: Implement any finalization logic that needs to occur at the end of the workflow.
            // This might include logging the workflow completion, updating status flags, performing cleanup, etc.
            // Example: WorkflowLogger.LogCompletion(context.Workflow.Id);

            // Return ExecutionResult.Next() to indicate that the finalization is complete
            // and the workflow can be considered finished.
            return ExecutionResult.Next();
        }
    }
}
