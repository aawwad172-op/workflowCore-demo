using Domain.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Represents a leave request submitted by an employee.
    /// </summary>
    public class LeaveRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier for the leave request.
        /// </summary>
        public Guid LeaveRequestId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the employee who submitted the leave request.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the date when the leave starts.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the leave ends.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the reason for the leave request.
        /// </summary>
        public string? Reason { get; set; }

        /// <summary>
        /// Gets or sets the current status of the leave request.
        /// </summary>
        public LeaveRequestStatus Status { get; set; }  // Changed to enum

        // Approvals[] property removed, since it can be retrieved from the User entity or directly via queries
    }
}
