namespace HelioApp.Application.DTOs.Common;

public sealed record PaginationResponse<TPagination>(
        IEnumerable<TPagination> Data,
        int TotalItems,
        int TotalPages,
        int CurrentPage,
        int PageSize
    );