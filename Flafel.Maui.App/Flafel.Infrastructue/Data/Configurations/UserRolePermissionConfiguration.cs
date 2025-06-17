
namespace Flafel.Infrastructure.Data.Configurations
{
    public class UserRolePermissionConfiguration : IEntityTypeConfiguration<UserRolePermission>
    {
        public void Configure(EntityTypeBuilder<UserRolePermission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, dbId => UserRolePermissionId.Of(dbId));

            builder.Property(x => x.UserRoleId).HasConversion(id => id.Value, dbId => UserRoleId.Of(dbId));

            builder.Property(x => x.RolePermission).HasDefaultValue(RolePermission.READ).HasConversion(enums => enums.ToString(), dbEnums => (RolePermission)Enum.Parse(typeof(RolePermission), dbEnums));

            //builder.Property(x => x.CreatedBy).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.LastModifiedBy).HasConversion(id => id == null ? (Guid?)null : id.Value, dbId => dbId.HasValue ? SystemUserId.Of(dbId.Value) : null);
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.LastModifiedBy).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
