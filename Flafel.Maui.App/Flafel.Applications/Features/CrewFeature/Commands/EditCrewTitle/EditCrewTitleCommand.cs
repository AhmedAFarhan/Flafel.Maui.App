using Flafel.Applications.Dtos.CrewDtos;

namespace Flafel.Applications.Features.CrewFeature.Commands.EditCrewTitle
{
	public record EditCrewTitleCommand(EditCrewTitleRequestDto CrewTitle) : ICommand<EditCrewTitleResult>;
	public record EditCrewTitleResult(bool IsSuccess);

	public class EditCrewTitleCommandValidator : AbstractValidator<EditCrewTitleCommand>
	{
		public EditCrewTitleCommandValidator()
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
