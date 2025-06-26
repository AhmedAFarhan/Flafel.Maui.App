using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Features.UserFeature.Queries.GetRolesByUser
{
    public class GetRolesByUserHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetRolesByUserQuery, GetRolesByUserResult>
    {
        public async Task<GetRolesByUserResult> Handle(GetRolesByUserQuery query, CancellationToken cancellationToken)
        {
            var roleRepo = unitOfWork.GetCustomRepository<IRoleRepository>();

            var userRoles = await roleRepo.GetUserRolesAsync(query.UserId, pageIndex : 1, pageSize : 500, cancellationToken: cancellationToken);

            return new GetRolesByUserResult(new PaginatedResult<UserRoleResponseDto>(1, 500, userRoles.Count(), userRoles.ToUserRoleResponseDtosList()));
        }
    }
}
