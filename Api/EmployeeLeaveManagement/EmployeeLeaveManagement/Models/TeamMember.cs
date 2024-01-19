namespace EmployeeLeaveManagement.Models
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }

        public Manager Manager { get; set; }
        public Employee Employee { get; set; }
    }
}
