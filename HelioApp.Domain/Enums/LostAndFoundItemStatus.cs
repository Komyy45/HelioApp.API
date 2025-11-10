namespace HelioApp.Domain.Enums;

public enum LostAndFoundItemStatus : byte
{
    Pending = 1,
    Approved,
    Rejected,
    Resolved,
    Expired
}