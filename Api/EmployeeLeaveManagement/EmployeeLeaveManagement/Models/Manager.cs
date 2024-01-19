namespace EmployeeLeaveManagement.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}
