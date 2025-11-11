namespace HelioApp.Application.DTOS.Properties;

public sealed record PropertyDto(
    Guid Id,
    string Title,
    IEnumerable<string> Images,
    decimal Price,
    DateTimeOffset? ExpirationDate,
    string Location,
    string ContactName,
    string ContactPhone
    );