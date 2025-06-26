using Flafel.Applications.Dtos.CrewDtos;

namespace Flafel.Applications.Features.CrewFeature.Query.GetCrewTitleById
{
    public class GetCrewTitleByIdHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetCrewTitleByIdQuery, GetCrewTitleByIdResult>
    {
        public async Task<GetCrewTitleByIdResult> Handle(GetCrewTitleByIdQuery query, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetRepository<CrewTitle>();

            var crewTitle = await repo.GetByIdAsync<CrewTitleId>(CrewTitleId.Of(query.Id), cancellationToken : cancellationToken);

            if(crewTitle is null)
            {
                throw new BadRequestException("نوع العمالة غير موجود");
            }           

            return new GetCrewTitleByIdResult(crewTitle.ToCrewTitlesDto());
        }
    }
}
