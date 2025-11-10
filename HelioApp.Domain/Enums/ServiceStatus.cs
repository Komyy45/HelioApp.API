namespace HelioApp.Domain.Enums;

public enum ServiceStatus : byte
{
    Pending = 1,
    Approved,
    Rejected,
    Suspended
}