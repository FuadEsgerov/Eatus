using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Entities.Identity;

namespace Repository.Data.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
