using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Features.UserFeature.Commands.Login
{
    public record LoginCommand(UserLoginRequestDto UserLogin) : ICommand<LoginResult>;
    public record LoginResult(UserLoginResponseDto user);

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserLogin).NotNull().WithMessage("معلومات المستخدم مطلوبة");

            RuleFor(x => x.UserLogin.Username).NotNull().WithMessage("يجب إدخال اسم المستخدم")
                                              .NotEmpty().WithMessage("يجب إدخال اسم المستخدم")
                                              .Must(userName => !string.IsNullOrWhiteSpace(userName)).WithMessage("لا يمكن اسم المستخدم ان يكون فارغ")
                                              .When(x => x.UserLogin is not null);

            RuleFor(x => x.UserLogin.Password).NotNull().WithMessage("يجب إدخال الرقم السرى")
                                              .NotEmpty().WithMessage("يجب إدخال الرقم السرى")
                                              .Must(passowrd => !string.IsNullOrWhiteSpace(passowrd)).WithMessage("لا يمكن الرقم السرى ان يكون فارغ")
                                              .When(x => x.UserLogin is not null);
        }
    }
}
