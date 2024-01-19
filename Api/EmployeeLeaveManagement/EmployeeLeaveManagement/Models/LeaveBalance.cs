namespace EmployeeLeaveManagement.Models
{
    public class LeaveBalance
    {
        public int BalanceId { get; set; }
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        public int Balance { get; set; }

        public Employee Employee { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
