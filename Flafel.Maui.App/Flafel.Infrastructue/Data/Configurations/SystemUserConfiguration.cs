namespace Flafel.Infrastructure.Data.Configurations
{
    public class SystemUserConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));

            builder.HasMany(o => o.UserRoles).WithOne().HasForeignKey(tb => tb.SystemUserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.UserName).HasMaxLength(30).IsRequired();

            //builder.Property(x => x.CrewId).HasConversion(id => id.Value, dbId => CrewId.Of(dbId));
            builder.Property(x => x.CrewId).IsRequired(false);
            builder.Property(x => x.CrewId).HasConversion(id => id == null ? (Guid?)null : id.Value, dbId => dbId.HasValue ? CrewId.Of(dbId.Value) : null);
            builder.HasOne<Crew>().WithMany().HasForeignKey(x => x.CrewId).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.CreatedBy).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.LastModifiedBy).HasConversion(id => id == null ? (Guid?)null : id.Value, dbId => dbId.HasValue ? SystemUserId.Of(dbId.Value) : null);
            //builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.LastModifiedBy).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
