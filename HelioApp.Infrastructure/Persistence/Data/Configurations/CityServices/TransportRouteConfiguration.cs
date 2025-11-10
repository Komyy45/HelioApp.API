using HelioApp.Domain.Entities.CityServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.CityServices
{
    public sealed class TransportRouteConfiguration : IEntityTypeConfiguration<TransportRoute>
    {
        public void Configure(EntityTypeBuilder<TransportRoute> builder)
        {
            builder.ToTable("TransportRoutes");

            builder.HasKey(tr => tr.Id);

            builder.Property(tr => tr.Id).HasColumnName("id");
            builder.Property(tr => tr.Name).HasColumnName("name").IsRequired();
            builder.Property(tr => tr.NameAr).HasColumnName("name_ar");
            builder.Property(tr => tr.RouteNumber).HasColumnName("route_number");

            builder.Property(tr => tr.TransportType).HasColumnName("transport_type").IsRequired();

            builder.Property(tr => tr.StartPoint).HasColumnName("start_point").IsRequired();
            builder.Property(tr => tr.EndPoint).HasColumnName("end_point").IsRequired();

            builder.Property(tr => tr.Stops)
                   .HasColumnName("stops")
                   .HasColumnType("nvarchar(max)");

            builder.Property(tr => tr.RouteMapUrl).HasColumnName("route_map_url");
            builder.Property(tr => tr.Fare).HasColumnName("fare");

            builder.Property(tr => tr.IsActive).HasColumnName("is_active").HasDefaultValue(true);

            builder.Property(tr => tr.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(tr => tr.UpdatedAt)
                   .HasColumnName("updated_at")
                   .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
