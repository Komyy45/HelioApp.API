namespace HelioApp.Application.DTOs.Offers
{
    public sealed record OfferCodeDto(
       Guid Id,
       Guid OfferId,
       string Code,
       bool IsUsed,
       string? UsedBy,
       DateTimeOffset? UsedAt,
       DateTimeOffset? ExpiresAt,
       DateTimeOffset CreatedAt
   );
}
