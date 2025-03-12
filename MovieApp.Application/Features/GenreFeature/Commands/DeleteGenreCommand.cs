using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;

namespace MovieApp.Application.Features.GenreFeature.Commands
{
	public class DeleteGenreCommand : IRequest<DeleteGenreResponseDto>
	{
		public int Id { get; set; }
	}
}
