using Flafel.Applications.Dtos.UserDtos;

namespace Flafel.Applications.Features.UserFeature.Commands.Register
{
    public record RegisterCommand(UserRegesterRequestDto UserRegister) : ICommand<RegisterResult>;
    public record RegisterResult(bool IsSuccess);
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserRegister).NotNull().WithMessage("معلومات المستخدم مطلوبة");

            RuleFor(x => x.UserRegister.Username).NotNull().WithMessage("يجب إدخال اسم المستخدم")
                                              .NotEmpty().WithMessage("يجب إدخال اسم المستخدم")
                                              .Must(userName => !string.IsNullOrWhiteSpace(userName)).WithMessage("لا يمكن اسم المستخدم ان يكون فارغ")
                                              .When(x => x.UserRegister is not null);

            RuleFor(x => x.UserRegister.Password).NotNull().WithMessage("يجب إدخال الرقم السرى")
                                              .NotEmpty().WithMessage("يجب إدخال الرقم السرى")
                                              .Must(passowrd => !string.IsNullOrWhiteSpace(passowrd)).WithMessage("لا يمكن الرقم السرى ان يكون فارغ")
                                              .When(x => x.UserRegister is not null);

            RuleFor(x => x.UserRegister.CrewId).NotEmpty().WithMessage("يجب إدخال اسم الموظف")
                                              .When(x => x.UserRegister is not null && x.UserRegister.CrewId is not null);
        }
    }
}
