using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Domain.LeaveSteps
{
    /// <summary>
    /// Represents a step in the leave request workflow that is responsible for notifying the employee
    /// of the decision regarding their leave request. This step is typically executed after the approval
    /// or rejection decision has been made.
    /// </summary>
    public class NotifyEmployeeStep : StepBody
    {
        /// <summary>
        /// Executes the logic associated with this step.
        /// This method is called when the workflow reaches the NotifyEmployeeStep,
        /// and it handles the task of notifying the employee about the status of their leave request.
        /// </summary>
        /// <param name="context">Provides context about the workflow execution,
        /// including data and the current state of the workflow.</param>
        /// <returns>An ExecutionResult indicating the next action to take.
        /// In this case, it moves the workflow to the next step after notifying the employee.</returns>
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // Log the execution of this step to the console for tracking purposes
            Console.WriteLine("NotifyEmployeeStep: Notifying employee of the decision...");

            // TODO: Implement logic to send a notification to the employee.
            // This could involve sending an email, SMS, or any other form of notification
            // Example: NotificationService.Notify(employeeEmail, "Your leave request has been approved/rejected");

            // Return ExecutionResult.Next() to indicate that the step completed successfully
            // and the workflow should proceed to the next step.
            return ExecutionResult.Next();
        }
    }
}
