namespace Flafel.Applications.Dtos.CrewDtos
{
	public class EditCrewTitleRequestDto
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
	}
}
