namespace BuildingBlocks.Pagination;
public class PaginationRequest
{
    public PaginationRequest()
    {
        // intentionally left blank
    }
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}

public class PaginationResponse
{
    public PaginationResponse()
    {
        // intentionally left blank
    }
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}