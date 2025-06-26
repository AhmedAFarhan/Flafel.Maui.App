using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Features.UserFeature.Queries.GetRoles
{
    public record GetRolesQuery() : IQuery<GetRolesResult>;
    public record GetRolesResult(PaginatedResult<RoleDto> Roles);
}
