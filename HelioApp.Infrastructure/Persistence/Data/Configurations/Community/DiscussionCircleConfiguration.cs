using HelioApp.Domain.Entities.Community;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelioApp.Infrastructure.Persistence.Data.Configurations.Community
{
    public sealed class DiscussionCircleConfiguration : IEntityTypeConfiguration<DiscussionCircle>
    {
        public void Configure(EntityTypeBuilder<DiscussionCircle> builder)
        {
            builder.ToTable("DiscussionCircles");

            builder.HasKey(dc => dc.Id);

            builder.Property(dc => dc.Id).HasColumnName("id");

            builder.Property(dc => dc.Name).HasColumnName("name").IsRequired();
            builder.Property(dc => dc.NameAr).HasColumnName("name_ar");
            builder.Property(dc => dc.Description).HasColumnName("description");
            builder.Property(dc => dc.IconUrl).HasColumnName("icon_url");
            builder.Property(dc => dc.CoverImageUrl).HasColumnName("cover_image_url");
            builder.Property(dc => dc.Rules).HasColumnName("rules");

            builder.Property(dc => dc.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            builder.Property(dc => dc.PostsCount).HasColumnName("posts_count").HasDefaultValue(0);
            builder.Property(dc => dc.MembersCount).HasColumnName("members_count").HasDefaultValue(0);

            builder.Property(dc => dc.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("SYSUTCDATETIME()");
            builder.Property(dc => dc.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
