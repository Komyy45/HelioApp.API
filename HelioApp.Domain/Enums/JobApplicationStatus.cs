namespace HelioApp.Domain.Enums;

public enum JobApplicationStatus : byte
{
    Pending = 1,
    Reviewed,
    Shortlisted,
    Accepted,
    Rejected
}