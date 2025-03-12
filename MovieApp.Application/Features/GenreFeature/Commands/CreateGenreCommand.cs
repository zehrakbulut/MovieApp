using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;

namespace MovieApp.Application.Features.GenreFeature.Commands
{
	public class CreateGenreCommand : IRequest<CreateGenreResponseDto>
	{
		public string Name { get; set; }
	}
}
