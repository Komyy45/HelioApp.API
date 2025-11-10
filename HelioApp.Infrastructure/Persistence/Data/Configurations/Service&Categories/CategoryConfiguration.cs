using HelioApp.Domain.Entities.Services___Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations
{
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.NameAr);
            builder.Property(c => c.IconUrl);
            builder.Property(c => c.Description);

            builder.Property(c => c.DisplayOrder).HasDefaultValue(0);
            builder.Property(c => c.IsActive).HasDefaultValue(true);

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(c => c.UpdatedAt);
        }
    }
}
