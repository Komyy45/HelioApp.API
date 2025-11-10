using HelioApp.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Authentication
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("ApplicationRoles"); 

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Description)
                   .HasMaxLength(500);

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("SYSUTCDATETIME()"); 
        }
    }
}
