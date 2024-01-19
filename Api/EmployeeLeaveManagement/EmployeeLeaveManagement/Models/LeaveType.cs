namespace EmployeeLeaveManagement.Models
{
    
        public class LeaveType
        {
            public int LeaveTypeId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int DefaultQuota { get; set; }

            public List<LeaveRequest> LeaveRequests { get; set; }
            public List<LeaveBalance> LeaveBalances { get; set; }
        }
}
