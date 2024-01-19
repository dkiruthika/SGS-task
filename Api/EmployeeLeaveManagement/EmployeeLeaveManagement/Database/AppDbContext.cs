using EmployeeLeaveManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeLeaveManagement.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveRequest>()
                .HasKey(lr => lr.RequestId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.Employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.LeaveType)
                .WithMany(lt => lt.LeaveRequests)
                .HasForeignKey(lr => lr.LeaveTypeId);
            modelBuilder.Entity<Manager>()
                .HasKey(m => m.ManagerId);
            modelBuilder.Entity<Manager>()
                .HasOne(m => m.Employee)
                .WithOne(e => e.Managers)
                .HasForeignKey<Manager>(m => m.EmployeeId);
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => tm.TeamMemberId);
            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Manager)
                .WithMany(m => m.TeamMembers)
                .HasForeignKey(tm => tm.ManagerId);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Employee)
                .WithMany(e => e.TeamMembers)
                .HasForeignKey(tm => tm.EmployeeId);
            modelBuilder.Entity<LeaveBalance>()
                .HasKey(lb => lb.BalanceId);

            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.Employee)
                .WithMany(e => e.LeaveBalances)
                .HasForeignKey(lb => lb.EmployeeId);

            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.LeaveType)
                .WithMany(lt => lt.LeaveBalances)
                .HasForeignKey(lb => lb.LeaveTypeId);
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);


        }
    }
}
