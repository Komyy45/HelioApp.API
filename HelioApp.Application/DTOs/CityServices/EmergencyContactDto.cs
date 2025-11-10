using HelioApp.Domain.Enums;

namespace HelioApp.Application.DTOs.CityServices;

public record EmergencyContactDto(
    Guid Id,
    string Title,
    string Number,
    EmergencyContactType Type
    );