using Flafel.Applications.Dtos.CrewDtos;

namespace Flafel.Applications.Features.CrewFeature.Query.GetCrewTitleById
{
    public record GetCrewTitleByIdQuery(Guid Id) : IQuery<GetCrewTitleByIdResult>;
    public record GetCrewTitleByIdResult(CrewTitleDto CrewTitle);
}
