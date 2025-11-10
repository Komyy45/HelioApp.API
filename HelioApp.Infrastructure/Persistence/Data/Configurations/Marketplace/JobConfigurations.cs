using HelioApp.Domain.Entities.Marketplace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Marketplace
{
    public sealed class JobConfigurations : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");

            builder.HasKey(j => j.Id);

            builder.HasIndex(j => j.PosterId);
            builder.HasIndex(j => j.Status);
            builder.HasIndex(j => j.Location);
            builder.HasIndex(j => j.CreatedAt);

            builder.Property(j => j.Id).HasColumnName("id");
            builder.Property(j => j.PosterId).HasColumnName("poster_id").IsRequired();
            builder.Property(j => j.Title).HasColumnName("title").IsRequired();
            builder.Property(j => j.CompanyName).HasColumnName("company_name");
            builder.Property(j => j.Description).HasColumnName("description").HasColumnType("nvarchar(max)").IsRequired();

            builder.Property(j => j.JobType)
                .HasColumnName("job_type")
                .HasConversion<byte>()
                .IsRequired();

            builder.Property(j => j.Category).HasColumnName("category");
            builder.Property(j => j.Location).HasColumnName("location").IsRequired();

            builder.Property(j => j.SalaryMin).HasColumnName("salary_min").HasPrecision(15, 2);
            builder.Property(j => j.SalaryMax).HasColumnName("salary_max").HasPrecision(15, 2);
            builder.Property(j => j.SalaryCurrency).HasColumnName("salary_currency").HasDefaultValue("EGP");

            builder.Property(j => j.SalaryPeriod)
                .HasColumnName("salary_period")
                .HasConversion<string>();

            builder.Property(j => j.ExperienceRequired).HasColumnName("experience_required");
            builder.Property(j => j.Requirements).HasColumnName("requirements").HasColumnType("nvarchar(max)");

            builder.Property(j => j.ContactEmail).HasColumnName("contact_email");
            builder.Property(j => j.ContactPhone).HasColumnName("contact_phone");

            builder.Property(j => j.Status)
                .HasColumnName("status")
                .HasConversion<byte>();

            builder.Property(j => j.ApplicationsCount).HasColumnName("applications_count").HasDefaultValue(0);
            builder.Property(j => j.ViewCount).HasColumnName("view_count").HasDefaultValue(0);

            builder.Property(j => j.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(j => j.UpdatedAt).HasColumnName("updated_at");
            builder.Property(j => j.DeletedAt).HasColumnName("deleted_at");
            builder.Property(j => j.ExpiresAt).HasColumnName("expires_at");

            // Relationships
            builder.HasOne(j => j.Poster)
                .WithMany()
                .HasForeignKey(j => j.PosterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
