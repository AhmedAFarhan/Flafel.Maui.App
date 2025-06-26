using Flafel.Applications.Dtos.CrewDtos;

namespace Flafel.Applications.Extensions
{
    public static class CrewExtensions
    {
        public static CrewTitleDto ToCrewTitlesDto(this CrewTitle title)
        {
            return new CrewTitleDto()
            {
                Id = title.Id.Value,
                Name = title.Name,
            };
        }

        public static IEnumerable<CrewTitleDto> ToCrewTitlesDtosList(this IEnumerable<CrewTitle> titles)
        {
            return titles.Select(title => new CrewTitleDto()
            {
                Id = title.Id.Value,
                Name = title.Name,
            });
        }
    }
}
