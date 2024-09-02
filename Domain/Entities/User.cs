namespace Domain.Entities;

/// <summary>
/// Represents a user in the leave request system, including employees and managers.
/// </summary>
public class User
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// This could be used for sending notifications related to leave requests.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the role of the user (e.g., Employee, Manager).
    /// This property determines the actions a user can perform within the system.
    /// </summary>
    public required string Role { get; set; }

    /// <summary>
    /// Gets or sets the list of leave requests submitted by the user.
    /// </summary>
    public ICollection<LeaveRequest>? SubmittedLeaveRequests { get; set; }

    /// <summary>
    /// Gets or sets the list of leave requests that the user is responsible for approving.
    /// </summary>
    public ICollection<Approval>? Approvals { get; set; }
}

