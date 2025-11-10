namespace HelioApp.Application.DTOs.Offers
{
    public sealed record OfferClaimDto(
     Guid Id,
     Guid OfferId,
     string UserId,
     string ClaimCode,
     bool IsRedeemed,
     DateTimeOffset? RedeemedAt,
     string? RedemptionLocation,
     DateTimeOffset ExpiresAt,
     DateTimeOffset ClaimedAt
 );

}
