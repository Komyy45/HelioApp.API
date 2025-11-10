using HelioApp.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Authentication
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.ProfilePictureUrl);
            builder.Property(u => u.Bio)
                   .HasMaxLength(1000);

            builder.Property(u => u.AccountType)
                   .HasConversion<byte>();

            builder.Property(u => u.Status)
                   .HasConversion<byte>();

            builder.Property(u => u.LastLoginAt);
            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(u => u.UpdatedAt);
            builder.Property(u => u.DeletedAt);

            // Relationships

            builder.HasMany(u => u.Posts)
                   .WithOne(p => p.Author)
                   .HasForeignKey(p => p.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Comments)
                   .WithOne(c => c.Author)
                   .HasForeignKey(c => c.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Likes)
                   .WithOne(l => l.User)
                   .HasForeignKey(l => l.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Reviews)
                   .WithOne(r => r.Author)
                   .HasForeignKey(r => r.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Properties)
                   .WithOne(p => p.Owner)
                   .HasForeignKey(p => p.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Services)
                   .WithOne(s => s.Provider)
                   .HasForeignKey(s => s.ProviderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.MarketplaceItems)
                   .WithOne(m => m.Seller)
                   .HasForeignKey(m => m.SellerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
