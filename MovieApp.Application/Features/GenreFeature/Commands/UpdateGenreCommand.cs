using MediatR;
using MovieApp.Application.Dtos.Requests.Genres;
using MovieApp.Application.Dtos.Responses.Genres;

namespace MovieApp.Application.Features.GenreFeature.Commands
{
	public class UpdateGenreCommand : IRequest<UpdateGenreResponseDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
