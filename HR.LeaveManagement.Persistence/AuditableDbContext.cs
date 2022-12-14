using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence
{
    public abstract class AuditableDbContext : DbContext
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            if (username == null)
            {
                username = "SYSTEM";
            }
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = username;
                }
            }
            var result = 1;
            try
            {
                result = await base.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
            }
            return result;


        }
    }
}
