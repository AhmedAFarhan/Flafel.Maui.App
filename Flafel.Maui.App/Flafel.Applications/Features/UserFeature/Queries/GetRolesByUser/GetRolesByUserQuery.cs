using Flafel.Applications.Dtos.UserDtos;


namespace Flafel.Applications.Features.UserFeature.Queries.GetRolesByUser
{
    public record GetRolesByUserQuery(Guid UserId) : IQuery<GetRolesByUserResult>;
    public record GetRolesByUserResult(PaginatedResult<UserRoleResponseDto> UserRoles);
}
