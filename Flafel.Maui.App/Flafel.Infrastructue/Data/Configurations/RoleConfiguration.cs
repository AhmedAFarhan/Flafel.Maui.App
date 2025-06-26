namespace Flafel.Infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, dbId => RoleId.Of(dbId));

            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.HasMany(r => r.UserRoles).WithOne(ur => ur.Role).HasForeignKey(ur => ur.RoleId).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.CreatedBy).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.LastModifiedBy).HasConversion(id => id == null ? (Guid?)null : id.Value, dbId => dbId.HasValue ? SystemUserId.Of(dbId.Value) : null);
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.LastModifiedBy).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
