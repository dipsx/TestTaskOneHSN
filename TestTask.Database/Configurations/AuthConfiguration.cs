using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Database.Configurations;
public sealed class AuthConfiguration : IEntityTypeConfiguration<Auth> {
    public void Configure(EntityTypeBuilder<Auth> builder) {
        builder.ToTable(nameof(Auth), nameof(Auth));

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Login).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.PasswordHash).HasMaxLength(1000).IsRequired();

        builder.Property(entity => entity.Salt).HasMaxLength(250).IsRequired();

        builder.Property(entity => entity.Roles).IsRequired();

        builder.Property(entity => entity.UserId).IsRequired();

        builder.HasOne(x => x.User).WithOne().HasForeignKey<Auth>(x => x.UserId).IsRequired();

        builder.HasIndex(entity => entity.Login).IsUnique();

        builder.HasIndex(entity => entity.UserId).IsUnique();
    }
}
