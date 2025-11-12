namespace HelioApp.Application.DTOs.Common;

public sealed record PaginationRequest(
    int PageIndex,
    int PageSize
    );