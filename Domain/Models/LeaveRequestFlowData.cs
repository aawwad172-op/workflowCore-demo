using System;

namespace Domain.Models
{
    /// <summary>
    /// Represents the data model used to store state and share information across the steps in the leave request workflow.
    /// This class encapsulates the data that is passed between the various steps of the workflow to maintain the workflow's context.
    /// </summary>
    public class LeaveRequestFlowData
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee requesting leave.
        /// This identifier is used to track the leave request back to the specific employee within the system.
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the number of leave days requested by the employee.
        /// This property tracks how many days of leave the employee is asking for in their request.
        /// </summary>
        public int LeaveDays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the leave request has been approved.
        /// This property is updated during the approval decision step and dictates the subsequent path of the workflow.
        /// </summary>
        public bool IsApproved { get; set; }

        /// <summary>
        /// Gets or sets any additional comments or remarks related to the leave request.
        /// This property can be used to store notes or feedback from the approver or other relevant information.
        /// </summary>
        public string Comments { get; set; }

        // Additional properties can be added here to capture more workflow-specific data,
        // such as the date of the request, the approver's name, or the reason for the leave.
    }
}
