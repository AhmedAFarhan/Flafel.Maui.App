using Flafel.Applications.Dtos.UserDtos;
using System.Security;

namespace Flafel.Applications.Extensions
{
    public static class UserExtensions
    {
        public static UserLoginResponseDto ToUserLoginResponseDto(this SystemUser user)
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
        public static IEnumerable<UserDto> ToUserDtosList(this IEnumerable<SystemUser> users)
        {
            return users.Select(user => new UserDto()
            {
                Id = user.Id.Value,
                Username = user.UserName,
                Title = "غير معروف",
            });
        }
        public static IEnumerable<RoleDto> ToRolesDtosList(this IEnumerable<Role> roles)
        {
            return roles.Select(role => new RoleDto()
            {
                Id = role.Id.Value,
                Name = role.Name,
            });
        }
        public static IEnumerable<UserRoleResponseDto> ToUserRoleResponseDtosList(this IEnumerable<Role> roles)
        {
            return roles.Select(userRole => new UserRoleResponseDto()
            {
                RoleId = userRole.Id.Value,
                RoleName = userRole.Name,
                IsActive = userRole.UserRoles.Any(),
                UserPermissionDtos = userRole.UserRoles.Any() ? userRole.UserRoles.First().UserRolePermissions.Select(permission => new UserPermissionDto()
                {
                    Id = permission.Id.Value,
                    RolePermission = permission.RolePermission
                }) : null 
            });
        }
    }
}
