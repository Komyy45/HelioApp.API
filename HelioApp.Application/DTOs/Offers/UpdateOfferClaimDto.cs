namespace HelioApp.Application.DTOs.Offers
{
    public sealed record UpdateOfferClaimDto(
       Guid Id,
       bool IsRedeemed,
       DateTime? RedeemedAt,
       string? RedemptionLocation
   );
}
