using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Features.UserFeature.Queries.GetUsers
{
    public record GetUsersQuery(PaginationRequest PaginationRequest) : IQuery<GetUsersResult>;
    public record GetUsersResult(PaginatedResult<UserDto> users);
}
