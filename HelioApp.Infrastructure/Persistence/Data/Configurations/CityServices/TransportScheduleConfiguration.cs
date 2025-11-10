using HelioApp.Domain.Entities.CityServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.CityServices
{
    public sealed class TransportScheduleConfiguration : IEntityTypeConfiguration<TransportSchedule>
    {
        public void Configure(EntityTypeBuilder<TransportSchedule> builder)
        {
            builder.ToTable("TransportSchedules");

            builder.HasKey(ts => ts.Id);

            builder.Property(ts => ts.Id).HasColumnName("id");

            builder.Property(ts => ts.RouteId).HasColumnName("route_id").IsRequired();

            builder.Property(ts => ts.DepartureTime).HasColumnName("departure_time").IsRequired();

            builder.Property(ts => ts.ArrivalTime).HasColumnName("arrival_time");

            builder.Property(ts => ts.FrequencyMinutes).HasColumnName("frequency_minutes");

            builder.Property(ts => ts.DaysOfWeek).HasColumnName("days_of_week");

            builder.Property(ts => ts.IsActive).HasColumnName("is_active").HasDefaultValue(true);

            builder.Property(ts => ts.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(ts => ts.UpdatedAt)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");

            // Relationships
            builder.HasOne(ts => ts.Route)
                   .WithMany()
                   .HasForeignKey(ts => ts.RouteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
