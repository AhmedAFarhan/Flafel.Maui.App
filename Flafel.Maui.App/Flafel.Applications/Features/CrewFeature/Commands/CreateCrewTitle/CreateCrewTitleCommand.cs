using Flafel.Applications.Dtos.CrewDtos;

namespace Flafel.Applications.Features.CrewFeature.Commands.CreateCrewTitle
{
	public record CreateCrewTitleCommand(AddNewCrewTitleRequestDto CrewTitle) : ICommand<CreateCrewTitleResult>;
	public record CreateCrewTitleResult(Guid Id);

	public class CreateCrewTitleCommandValidator : AbstractValidator<CreateCrewTitleCommand>
	{
		public CreateCrewTitleCommandValidator()
		{
			RuleFor(x => x.CrewTitle).NotNull().WithMessage("معلومات العمالة مطلوبة");

			RuleFor(x => x.CrewTitle.Name).NotNull().WithMessage("يجب إدخال نوع العمالة")
										  .NotEmpty().WithMessage("يجب إدخال نوع العمالة")
										  .Must(userName => !string.IsNullOrWhiteSpace(userName)).WithMessage("لا يمكن نوع العمالة ان يكون فارغ")
										  .MaximumLength(150).WithMessage("نوع العمالة لا يجب ان يتجاوز 150 حرف")
										  .When(x => x.CrewTitle is not null);
		}
	}
}
