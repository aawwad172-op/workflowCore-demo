using System;

namespace Domain.Entities
{
    /// <summary>
    /// Represents a request to approve a leave request workflow.
    /// This class encapsulates the necessary data required for a manager to approve a leave request within the workflow system.
    /// </summary>
    public class ApprovalLeaveRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the workflow being approved.
        /// This identifier is typically a string generated by the workflow engine (WorkflowCore) when the workflow is started.
        /// It is used to uniquely identify the specific workflow instance that the approval applies to.
        /// </summary>
        public required string WorkflowId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the manager who is approving the leave request.
        /// The manager's ID is stored as a GUID to ensure a globally unique identifier across the system.
        /// This helps in tracking which manager approved the leave request.
        /// </summary>
        public required Guid ManagerId { get; set; }

        /// <summary>
        /// Gets or sets any additional comments provided by the manager during the approval process.
        /// This field is optional and allows the manager to provide feedback, notes, or reasons for their approval decision.
        /// </summary>
        public string? Comments { get; set; }
    }
}
