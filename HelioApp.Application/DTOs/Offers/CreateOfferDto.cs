namespace HelioApp.Application.DTOs.Offers
{
    public sealed record CreateOfferDto(
        string Title,
        string Description,
        string? TermsAndConditions,
        string PictureUrl,
        string OfferType,
        int? DiscountPercentage,
        decimal? DiscountAmount,
        string RedemptionMethod,
        bool RequiresCode,
        string Status,
        DateTime StartDate,
        DateTime EndDate,
        Guid CreatedBy
    );
}
