using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;

namespace MovieApp.Application.Features.DirectorFeature.Commands
{
	public class UpdateDirectorCommand : IRequest<UpdateDirectorResponseDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
	}
}
