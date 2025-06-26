
namespace Flafel.Applications.Features.CrewFeature.Commands.CreateCrewTitle
{
	public class CreateCrewTitleHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateCrewTitleCommand, CreateCrewTitleResult>
	{
		public async Task<CreateCrewTitleResult> Handle(CreateCrewTitleCommand command, CancellationToken cancellationToken)
		{
			var repo = unitOfWork.GetRepository<CrewTitle>();

			var crewTitle = await repo.GetByPropertyAsync(c => c.Name == command.CrewTitle.Name, cancellationToken: cancellationToken);

			if(crewTitle is not null)
			{
				throw new BadRequestException("نوع العمالة موجود بالفعل");
			}

			var createdCrewTitle = CrewTitle.Create(CrewTitleId.Of(Guid.NewGuid()), command.CrewTitle.Name);

			await repo.AddOneAsync(createdCrewTitle, cancellationToken:cancellationToken);

			await unitOfWork.SaveChangesAsync(cancellationToken);

			return new CreateCrewTitleResult(createdCrewTitle.Id.Value);
		}
	}
}
