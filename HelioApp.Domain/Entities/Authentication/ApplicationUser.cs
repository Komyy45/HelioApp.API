using HelioApp.Domain.Common;
using HelioApp.Domain.Entities.Community;
using HelioApp.Domain.Entities.Favorites_Interactions;
using HelioApp.Domain.Entities.Marketplace;
using HelioApp.Domain.Entities.Messaging;
using HelioApp.Domain.Entities.Properties;
using HelioApp.Domain.Entities.Reviews;
using HelioApp.Domain.Entities.Services___Categories;
using HelioApp.Domain.Enums;

namespace HelioApp.Domain.Entities.Authentication;

public sealed class ApplicationUser : BaseEntity<string>
{
    public string Email { get; set; } = default!;
    public string NormalizedEmail { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    
    public string PasswordHash { get; set; } = default!;
    public string? ProfilePictureUrl { get; set; }
    public string? Bio { get; set; }

    public AccountType AccountType { get; set; }
    public AccountStatus Status { get; set; }


    public DateTimeOffset? LastLoginAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public ICollection<Post>? Posts { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Like>? Likes { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<Property>? Properties { get; set; }
    public ICollection<Service>? Services { get; set; }
   public ICollection<Favorite>? Favorites { get; set; }
    public ICollection<MarketplaceItem>? MarketplaceItems { get; set; }
    public ICollection<Message>? Messages { get; set; }
}