namespace Flafel.Applications.Features.CrewFeature.Commands.EditCrewTitle
{
	public class EditCrewTitleHandler(IUnitOfWork unitOfWork) : ICommandHandler<EditCrewTitleCommand, EditCrewTitleResult>
	{
		public async Task<EditCrewTitleResult> Handle(EditCrewTitleCommand command, CancellationToken cancellationToken)
		{
			var repo = unitOfWork.GetRepository<CrewTitle>();

			var crewTitle = await repo.GetByIdAsync<CrewTitleId>(CrewTitleId.Of(command.CrewTitle.Id), cancellationToken : cancellationToken);

			if (crewTitle is null)
			{
				throw new BadRequestException("نوع العمالة غير موجود");
			}

			var existCrewTitle = await repo.GetByPropertyAsync(c => c.Name == command.CrewTitle.Name, cancellationToken: cancellationToken);

			if (existCrewTitle is not null && existCrewTitle.Id != crewTitle.Id)
			{
				throw new BadRequestException("نوع العمالة موجود بالفعل");
			}			

			crewTitle.Update(command.CrewTitle.Name);

			repo.UpdateEntity(crewTitle);

			await unitOfWork.SaveChangesAsync(cancellationToken);

			return new EditCrewTitleResult(true);
		}
	}
}
