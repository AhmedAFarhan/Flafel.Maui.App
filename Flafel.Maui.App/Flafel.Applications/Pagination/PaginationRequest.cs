
namespace Flafel.Applications.Pagination
{
    public record PaginationRequest(int PageIndex = 0, int PageSize = 3, string? FilterQuery = null, string? FilterValue = null);
}
