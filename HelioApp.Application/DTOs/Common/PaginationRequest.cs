namespace HelioApp.Application.DTOs.Common;

public record PaginationRequest(
    int Page,
    int Size
    );