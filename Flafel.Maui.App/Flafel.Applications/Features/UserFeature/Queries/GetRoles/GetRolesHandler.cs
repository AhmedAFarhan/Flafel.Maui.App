using Flafel.Applications.Dtos.UserDtos;
using Flafel.Applications.Pagination;


namespace Flafel.Applications.Features.UserFeature.Queries.GetRoles
{
    public class GetRolesHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetRolesQuery, GetRolesResult>
    {
        public async Task<GetRolesResult> Handle(GetRolesQuery query, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetRepository<Role>();

            var totalCount = await repo.GetCountAsync(cancellationToken: cancellationToken);

            var roles = await repo.GetAllAsync(pageSize: 500, cancellationToken: cancellationToken);

            return new GetRolesResult(new PaginatedResult<RoleDto>(1, 500, totalCount, roles.ToRolesDtosList()));
        }
    }
}
