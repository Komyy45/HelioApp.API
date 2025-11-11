namespace HelioApp.Application.DTOS.Properties;

public sealed record PropertyDetailsDto(
        Guid Id,
        string Title,
        string Description,
        IEnumerable<string> Images,
        decimal Price,
        DateTimeOffset? ExpirationDate,
        string Location,
        string ContactName,
        string ContactPhone,
        string Amenities
    );