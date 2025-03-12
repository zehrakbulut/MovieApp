using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;

namespace MovieApp.Application.Features.MovieFeature.Commands
{
	public class DeleteMovieCommand : IRequest<DeleteMovieResponseDto>
	{
		public int Id { get; set; }
	}
}
