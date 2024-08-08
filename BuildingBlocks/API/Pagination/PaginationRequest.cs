using TypeGen.Core.TypeAnnotations;

namespace BuildingBlocks.API.Pagination;
[ExportTsInterface]
public class PaginationRequest
{
    public PaginationRequest()
    {
        // intentionally left blank
    }

    public PaginationRequest(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 10;
}