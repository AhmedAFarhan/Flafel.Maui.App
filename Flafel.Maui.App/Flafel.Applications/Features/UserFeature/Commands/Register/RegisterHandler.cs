using Flafel.Applications.Dtos.UserDtos;

using Microsoft.AspNetCore.Identity;

namespace Flafel.Applications.Features.UserFeature.Commands.Register
{
    public class RegisterHandler(IUnitOfWork unitOfWork, IPasswordHasher<object> passwordHasher) : ICommandHandler<RegisterCommand, RegisterResult>
    {
        public async Task<RegisterResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetCustomRepository<IUserRepository>();

            var userData = command.UserRegister;

            //Check user existence
            var isUserExist = await repo.IsUserExist(userData.Username, cancellationToken : cancellationToken);

            if (isUserExist)
            {
                throw new BadRequestException("اسم المستخدم موجود من قبل");
            }

            var createdUser = CreateNewUser(userData);

            await repo.AddOneAsync(createdUser, cancellationToken: cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new RegisterResult(true);
        }

        private SystemUser CreateNewUser(UserRegesterRequestDto user)
        {
            var newUser = SystemUser.Create(SystemUserId.Of(Guid.NewGuid()), CrewId.OfNullable(user.CrewId), user.Username, passwordHasher.HashPassword(null, user.Password));

            foreach(var userRole in user.UserRoleDtos)
            {
                var newUserRole = newUser.AddUserRole(RoleId.Of(userRole.RoleId));

                foreach(var userPermission in userRole.UserPermissionsDto)
                {
                    newUserRole.AddPermission(userPermission.RolePermission);
                }
            }

            return newUser;
        }
    }
}
