﻿using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence
{
    public class LeaveManagementDbContext: AuditableDbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext>options)
            :base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementDbContext).Assembly);

        } 
        public DbSet<LeaveRequest> LeaveRequests{ get; set; }
        public DbSet<LeaveType> LeaveTypes{ get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    }
}