using Flafel.Applications.Dtos.CrewDtos;

namespace Flafel.Applications.Features.CrewFeature.Query.GetCrewTitles
{
    public record GetCrewTitlesQuery(PaginationRequest PaginationRequest) : IQuery<GetCrewTitlesResult>;
    public record GetCrewTitlesResult(PaginatedResult<CrewTitleDto> CrewTitlesPage);
}
