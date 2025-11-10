namespace HelioApp.Domain.Enums;

public enum JobStatus : byte
{
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    Closed = 4,
    Expired = 5
}