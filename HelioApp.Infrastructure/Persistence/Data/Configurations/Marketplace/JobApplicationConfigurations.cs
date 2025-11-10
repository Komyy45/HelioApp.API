using HelioApp.Domain.Entities.Marketplace;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Marketplace
{
    public sealed class JobApplicationConfigurations : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");

            builder.HasKey(a => a.Id);

            builder.HasIndex(a => a.JobId);
            builder.HasIndex(a => a.ApplicantId);

            builder.Property(a => a.Id).HasColumnName("id");
            builder.Property(a => a.JobId).HasColumnName("job_id").IsRequired();
            builder.Property(a => a.ApplicantId).HasColumnName("applicant_id").IsRequired();

            builder.Property(a => a.CoverLetter).HasColumnName("cover_letter").HasColumnType("nvarchar(max)");
            builder.Property(a => a.ResumeUrl).HasColumnName("resume_url");
            builder.Property(a => a.ContactPhone).HasColumnName("contact_phone");
            builder.Property(a => a.ContactEmail).HasColumnName("contact_email");

            builder.Property(a => a.Status)
                .HasColumnName("status")
                .HasConversion<byte>();

            builder.Property(a => a.AppliedAt)
                .HasColumnName("applied_at")
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(a => a.UpdatedAt).HasColumnName("updated_at");

            // Relationships
            builder.HasOne(a => a.Job)
                .WithMany()
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Applicant)
                .WithMany()
                .HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
