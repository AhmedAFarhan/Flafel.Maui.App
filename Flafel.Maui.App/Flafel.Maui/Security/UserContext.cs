using Flafel.Applications.Contracts.UserContext;
using Flafel.Applications.Exceptions;
using System.Security.Claims;

namespace Flafel.Maui.Security
{
    public class UserContext(CustomAuthStateProvider customAuthStateProvider) : IUserContext
    {
        public Guid GetUserId()
        {
            if(customAuthStateProvider.CurrentUser is not null)
            {
                return customAuthStateProvider.CurrentUser.Id;
            }
            throw new BadRequestException("حدث خطأ ما");
        }
    }
}
