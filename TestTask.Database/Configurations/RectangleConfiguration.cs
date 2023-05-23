using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Database.Configurations {
    public sealed class RectangleConfiguration : IEntityTypeConfiguration<Rectangle> {
        public void Configure(EntityTypeBuilder<Rectangle> builder) {
            builder.ToTable(nameof(Rectangle), nameof(Rectangle));

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id).ValueGeneratedOnAdd().IsRequired();


            builder.Property(entity => entity.X1).IsRequired();

            builder.Property(entity => entity.Y1).IsRequired();

            builder.Property(entity => entity.X2).IsRequired();

            builder.Property(entity => entity.Y2).IsRequired();

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Rectangle_XY_Check",
                $"{nameof(Rectangle.X1)} < {nameof(Rectangle.X2)} AND {nameof(Rectangle.Y1)} < {nameof(Rectangle.Y2)}"
            ));

            builder.HasIndex(entity => new { entity.X1, entity.Y1, entity.X2, entity.Y2 }).IsUnique();
        }
    }
}
