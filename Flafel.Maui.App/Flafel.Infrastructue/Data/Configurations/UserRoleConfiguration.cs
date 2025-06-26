
namespace Flafel.Infrastructure.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, dbId => UserRoleId.Of(dbId));

            builder.HasMany(o => o.UserRolePermissions).WithOne().HasForeignKey(tb => tb.UserRoleId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.SystemUserId).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));

            builder.Property(x => x.RoleId).HasConversion(id => id.Value, dbId => RoleId.Of(dbId));
            //builder.HasOne<Role>(x => x.Role).WithMany().HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.CreatedBy).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.LastModifiedBy).HasConversion(id => id == null ? (Guid?)null : id.Value, dbId => dbId.HasValue ? SystemUserId.Of(dbId.Value) : null);
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.LastModifiedBy).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
