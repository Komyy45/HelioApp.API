namespace HelioApp.Application.DTOs.Common;

public sealed record PaginationResponse<TPagination>(
        TPagination Data,
        Pagination Pagination
    );

public sealed record Pagination(
    int TotalItems,
    int TotalPages,
    int CurrentPages,
    int PageSize
    );