using System;

namespace Domain.Entities;

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
    /// Gets or sets the current status of the leave request (e.g., Pending, Approved, Rejected).
    /// </summary>
    public required string Status { get; set; }

    /// <summary>
    /// Gets or sets the list of approvals for this leave request.
    /// </summary>
    public ICollection<Approval>? Approvals { get; set; }
}
