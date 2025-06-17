namespace Flafel.Infrastructure.Data.Configurations
{
    public class CrewConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, dbId => CrewId.Of(dbId));

            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.HasIndex(x => x.Mobile).IsUnique();
            builder.Property(x => x.Mobile).HasMaxLength(11).IsRequired();

            builder.Property(x => x.SalaryType).HasDefaultValue(SalaryType.DAILY).HasConversion(enums => enums.ToString(), dbEnums => (SalaryType)Enum.Parse(typeof(SalaryType), dbEnums));

            builder.Property(x => x.CrewTitleId).HasConversion(id => id.Value, dbId => CrewTitleId.Of(dbId));
            builder.HasOne<CrewTitle>().WithMany().HasForeignKey(x => x.CrewTitleId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.CreatedBy).HasConversion(id => id.Value, dbId => SystemUserId.Of(dbId));
            builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.CreatedBy).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.LastModifiedBy).HasConversion(id => id == null ? (Guid?)null : id.Value, dbId => dbId.HasValue ? SystemUserId.Of(dbId.Value) : null);
            builder.HasOne<SystemUser>().WithMany().HasForeignKey(x => x.LastModifiedBy).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
