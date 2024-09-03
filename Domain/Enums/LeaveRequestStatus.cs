namespace Domain.Enums;

/// <summary>
/// Represents the status of a leave request.
/// </summary>
public enum LeaveRequestStatus
{
    Pending,     // The leave request is waiting for approval
    Approved,    // The leave request has been approved
    Rejected     // The leave request has been rejected
}
