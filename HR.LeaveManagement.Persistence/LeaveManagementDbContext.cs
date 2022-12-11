using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence
{
    public class LeaveManagementDbContext:DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext>options)
            :base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          // modelBuilder.Entity<LeaveRequest>().Property(t=>t.R)

        } 
        public DbSet<LeaveRequest> LeaveRequests{ get; set; }
        public DbSet<LeaveType> LeaveTypes{ get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    }
}