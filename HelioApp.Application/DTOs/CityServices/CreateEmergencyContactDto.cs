using HelioApp.Domain.Enums;

namespace HelioApp.Application.DTOs.CityServices;

public sealed record CreateEmergencyContactDto(
    string Title,
    string Number,
    EmergencyContactType Type
    );