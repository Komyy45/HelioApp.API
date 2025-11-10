using HelioApp.Domain.Enums;

namespace HelioApp.Application.DTOs.CityServices;

public sealed record UpdateEmergencyContactDto(
    Guid Id,
    string Title,
    string Number,
    EmergencyContactType Type);