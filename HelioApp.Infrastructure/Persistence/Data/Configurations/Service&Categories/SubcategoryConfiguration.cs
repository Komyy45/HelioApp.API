using HelioApp.Domain.Entities.Services___Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations
{
    public sealed class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("Subcategories");

            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.Subcategories)
                   .HasForeignKey(sc => sc.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(sc => sc.Name).IsRequired();
            builder.Property(sc => sc.NameAr);
            builder.Property(sc => sc.Description);

            builder.Property(sc => sc.DisplayOrder);
            builder.Property(sc => sc.IsActive).HasDefaultValue(true);

            builder.Property(sc => sc.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(sc => sc.UpdatedAt);
        }
    }
}
