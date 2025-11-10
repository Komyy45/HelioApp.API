namespace HelioApp.Application.DTOs.Offers
{
    public sealed record UpdateOfferCodeDto(
        Guid Id,
        bool IsUsed,
        Guid? UsedBy,
        DateTime? UsedAt
    );
}
