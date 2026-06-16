namespace BuildingBlocks.Pagination;

public record PaginationRequest(int PageIntex = 0, int PageSize = 10);