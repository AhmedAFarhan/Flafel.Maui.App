using Microsoft.AspNetCore.Identity;

namespace Flafel.Applications.Features.UserFeature.Commands.Login
{
    public class LoginHandler(IUnitOfWork unitOfWork, IPasswordHasher<object> passwordHasher) : ICommandHandler<LoginCommand, LoginResult>
    {
        public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetCustomRepository<IUserRepository>();

            var user = await repo.GetUserByUsernameAsync(command.UserLogin.Username, cancellationToken: cancellationToken);

            if (user is null || passwordHasher.VerifyHashedPassword(null, user.PasswordHash, command.UserLogin.Password) == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("اسم المستخدم او الرقم السرى غير صحيح");
            }

            var userDto = user.ToUserLoginResponseDto();

            return new LoginResult(userDto);
        }
    }
}
