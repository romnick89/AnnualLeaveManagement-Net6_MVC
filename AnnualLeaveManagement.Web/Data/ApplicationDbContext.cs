using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnnualLeaveManagement.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AnnualLeaveType> AnnualLeaveTypes { get; set; }
        public DbSet<AnnualLeaveAllocation> AnnualLeaveAllocations { get; set; }

    }
}