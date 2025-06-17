using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Extensions
{
    public static class UserExtensions
    {
        public static UserLoginResponseDto ToUserDto(this SystemUser user)
        {
            return new UserLoginResponseDto()
            {
                Id = user.Id.Value,
                Username = user.UserName,
                FullName = null,
                UserRolesDtos = user.UserRoles.Select(userRole => new UserRoleDto()
                {
                    Id = userRole.Id.Value,
                    RoleId = userRole.RoleId.Value,
                    Role = userRole.Role.Name,
                    UserPermissionsDto = userRole.UserRolePermissions.Select(permission => new UserPermissionDto()
                    {
                        Id = permission.Id.Value,
                        RolePermission = permission.RolePermission
                    })
                })
            };
        }
    }
}
