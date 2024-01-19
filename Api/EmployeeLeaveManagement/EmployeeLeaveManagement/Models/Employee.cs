namespace EmployeeLeaveManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; } = 1000;
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public List<LeaveRequest> LeaveRequests { get; set; }
        public Manager Managers { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        public List<LeaveBalance> LeaveBalances { get; set; }
    }
}
