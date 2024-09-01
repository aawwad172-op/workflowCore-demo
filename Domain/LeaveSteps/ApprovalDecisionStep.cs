using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Domain.LeaveSteps
{
    /// <summary>
    /// Represents a step in the workflow that processes the approval decision for a leave request.
    /// This step determines the flow of the workflow based on whether the leave request is approved or rejected.
    /// </summary>
    public class ApprovalDecisionStep : StepBody
    {
        /// <summary>
        /// Gets or sets a value indicating whether the leave request has been approved.
        /// This property will be used to decide the workflow's next steps.
        /// </summary>
        public bool IsApproved { get; set; } // Example property to capture the decision

        /// <summary>
        /// Executes the logic associated with this step.
        /// This method is called when the workflow reaches the ApprovalDecisionStep.
        /// </summary>
        /// <param name="context">Provides context about the workflow execution,
        /// including data and the current state of the workflow.</param>
        /// <returns>An ExecutionResult that indicates the next action to take.
        /// In this case, it moves the workflow to the next step based on the approval decision.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // Log the execution of this step to the console for tracking purposes
            Console.WriteLine("ApprovalDecisionStep: Processing approval decision...");

            // TODO: Implement logic to handle the decision.
            // If the request is approved, proceed with the next step in the approved workflow path.
            // If the request is rejected, handle the rejection accordingly.
            // Example: if (IsApproved) { /* proceed with approved workflow */ } else { /* handle rejection */ }

            // Return ExecutionResult.Next() to indicate that the step completed successfully
            // and the workflow should proceed to the next step.
            return ExecutionResult.Next();
        }
    }
}

