using Flafel.Applications.Dtos.CrewDtos;
namespace Flafel.Applications.Features.CrewFeature.Query.GetCrewTitles
{
    public class GetCrewTitlesHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetCrewTitlesQuery, GetCrewTitlesResult>
    {
        public async Task<GetCrewTitlesResult> Handle(GetCrewTitlesQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var filterQuery = query.PaginationRequest.FilterQuery;
            var filterValue = query.PaginationRequest.FilterValue;

            var repo = unitOfWork.GetRepository<CrewTitle>();

            var totalCount = await repo.GetCountAsync(filterQuery: filterQuery, filterValue: filterValue, cancellationToken: cancellationToken);

            var crewTitles = await repo.GetAllAsync(pageIndex: pageIndex, pageSize: pageSize, filterQuery: filterQuery, filterValue: filterValue, cancellationToken: cancellationToken);

            return new GetCrewTitlesResult(new PaginatedResult<CrewTitleDto>(pageIndex, pageSize, totalCount, crewTitles.ToCrewTitlesDtosList()));
        }
    }
}
