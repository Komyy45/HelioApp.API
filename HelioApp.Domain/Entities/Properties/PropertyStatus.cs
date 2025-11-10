namespace HelioApp.Domain.Entities.Properties;

public enum PropertyStatus : byte
{
    Pending,
    Approved,
    Rejected,
    Sold,
    Rented,
    Expired
}