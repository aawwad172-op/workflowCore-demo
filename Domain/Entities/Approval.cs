using System;

namespace Domain.Entities;

/// <summary>
/// Represents the approval or rejection of a leave request by a manager.
/// </summary>
public class Approval
{
    /// <summary>
    /// Gets or sets the unique identifier for the approval.
    /// </summary>
    public Guid ApprovalId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the leave request being approved or rejected.
    /// </summary>
    public Guid LeaveRequestId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the manager who approved or rejected the leave request.
    /// </summary>
    public Guid ManagerId { get; set; }

    /// <summary>
    /// Gets or sets the date when the approval or rejection was made.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the decision made by the manager (e.g., Approved, Rejected).
    /// </summary>
    public required string Decision { get; set; }

    /// <summary>
    /// Gets or sets any comments or notes provided by the manager.
    /// </summary>
    public string? Comments { get; set; }
}
