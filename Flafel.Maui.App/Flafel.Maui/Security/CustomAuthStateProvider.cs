using Blazored.LocalStorage;
using Flafel.Applications.Dtos.UserDtos;
using Flafel.Applications.UnitOfWork;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Flafel.Maui.Security
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private const string UserInfoKey = "flafelAuthUser";
        private UserLoginResponseDto? _currentUser;

        public bool IsSignedIn { get => _currentUser is null ? false : true; }
        public UserLoginResponseDto? CurrentUser { get => _currentUser is null ? null : _currentUser; }

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

		public async Task SignedInAsync(UserLoginResponseDto currentUser)
        {
            try
            {
                _currentUser = currentUser;
                await _localStorage.SetItemAsync(UserInfoKey, currentUser);
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }
            catch
            {
                throw;
            }
        }

		public async Task SignedOutAsync()
        {
            try
            {
                _currentUser = null;
                await _localStorage.RemoveItemAsync(UserInfoKey);
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }
            catch
            {
                throw;
            }
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var username = await _localStorage.GetItemAsync<UserLoginResponseDto>(UserInfoKey);

                _currentUser = username;

                if (_currentUser is not null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, _currentUser.Username),
                        new Claim(ClaimTypes.NameIdentifier, _currentUser.Id.ToString())
                    };

                    foreach (var role in _currentUser.UserRolesDtos)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Role));
                        foreach (var permission in role.UserPermissionsDto)
                        {
                            claims.Add(new Claim($"{role.Role}Permission", permission.RolePermission.ToString()));
                        }
                    }

                    var identity = new ClaimsIdentity(claims, "CustomAuth");

                    return new AuthenticationState(new ClaimsPrincipal(identity));
                }

                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            catch
            {
                throw;
            }
        }
    }
}
