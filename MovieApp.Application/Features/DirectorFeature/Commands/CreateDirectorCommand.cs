using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;

namespace MovieApp.Application.Features.DirectorFeature.Commands
{
	public class CreateDirectorCommand : IRequest<CreateDirectorResponseDto>
	{
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
