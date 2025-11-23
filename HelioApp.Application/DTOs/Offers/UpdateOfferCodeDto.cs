namespace HelioApp.Application.DTOs.Offers
{
    public sealed record UpdateOfferCodeDto(
        Guid Id,
        bool IsUsed,
        string? UsedBy,
        DateTimeOffset? UsedAt
    );
}
