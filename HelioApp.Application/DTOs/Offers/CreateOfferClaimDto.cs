namespace HelioApp.Application.DTOs.Offers
{
    public sealed record CreateOfferClaimDto(
        Guid OfferId,
        Guid UserId,
        string ClaimCode,
        DateTime ExpiresAt
    );
}
