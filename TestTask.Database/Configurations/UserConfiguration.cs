
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Database.Configurations {
    public sealed class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable(nameof(User), nameof(User));

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(entity => entity.Email).HasMaxLength(250).IsRequired();

            builder.HasIndex(entity => entity.Email).IsUnique();

            builder.Property(entity => entity.PasswordHash).HasMaxLength(1000).IsRequired();

            builder.Property(entity => entity.Roles).IsRequired();
        }
    }
}
