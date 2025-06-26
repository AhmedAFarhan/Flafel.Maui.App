using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Features.UserFeature.Queries.GetUsers
{
    public class GetUsersHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetUsersQuery, GetUsersResult>
    {
        public async Task<GetUsersResult> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var filterQuery = query.PaginationRequest.FilterQuery;
            var filterValue = query.PaginationRequest.FilterValue;

            var repo = unitOfWork.GetRepository<SystemUser>();

            var totalCount = await repo.GetCountAsync(filterQuery: filterQuery, filterValue: filterValue, cancellationToken: cancellationToken);

            var users = await repo.GetAllAsync(pageIndex: pageIndex, pageSize: pageSize, filterQuery: filterQuery, filterValue: filterValue, cancellationToken: cancellationToken);

            return new GetUsersResult(new PaginatedResult<UserDto>(pageIndex, pageSize, totalCount, users.ToUserDtosList()));
        }
    }
}
