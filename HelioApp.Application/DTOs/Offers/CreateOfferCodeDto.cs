namespace HelioApp.Application.DTOs.Offers
{
    public sealed record CreateOfferCodeDto(
        Guid OfferId,
        string Code,
        DateTimeOffset ExpiresAt
    );
}
