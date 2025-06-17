using System.Reflection;

namespace Flafel.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Crew> Crews => Set<Crew>();
        public DbSet<SystemUser> SystemUsers => Set<SystemUser>();
        public DbSet<CrewTitle> CrewTitles => Set<CrewTitle>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<UserRolePermission> UserRolePermissions => Set<UserRolePermission>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
