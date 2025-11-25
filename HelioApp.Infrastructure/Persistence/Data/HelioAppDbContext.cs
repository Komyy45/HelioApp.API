using System.Reflection;
using HelioApp.Domain.Entities.Community;
using HelioApp.Domain.Entities.ContentManagement;
using HelioApp.Domain.Entities.Properties;
using HelioApp.Domain.Entities.Reviews;
using HelioApp.Domain.Entities.Services___Categories;
using Microsoft.EntityFrameworkCore;

namespace HelioApp.Infrastructure.Persistence.Data;

public sealed class HelioAppDbContext(DbContextOptions<HelioAppDbContext> options)
    : DbContext(options)
{
    public DbSet<Category> Categories { get; private set; } = default!;
    public DbSet<Subcategory> Subcategories { get; private set; } = default!;
    public DbSet<Service> Services { get; private set; } = default!;
    public DbSet<Property> Properties { get; private set; } = default!;
    
    public DbSet<Review> Reviews { get; private set; } = default!;
    public DbSet<Comment> Comments { get; private set; } = default!;
    public DbSet<Post> Posts { get; private set; } = default!;
    public DbSet<OfferClaim> OfferClaims { get; private set; } = default!;
    public DbSet<OfferCode> OfferCodes { get; private set; } = default!;
    public DbSet<Offer> Offers { get; private set; } = default!;
    public DbSet<Notification> Notifications { get; private set; } = default!;
    public DbSet<UserNotification> UserNotifications { get; private set; } = default!;
    public DbSet<Ad> Ads { get; private set; } = default!;
    public DbSet<News> News { get; private set; } = default!;



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
                            .HavePrecision(18, 2);
    }
}
