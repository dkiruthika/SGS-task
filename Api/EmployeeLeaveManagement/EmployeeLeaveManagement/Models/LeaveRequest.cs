namespace EmployeeLeaveManagement.Models
{
    public class LeaveRequest
    {
        public int RequestId { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime? DateResolved { get; set; }

        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
