using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;

namespace MovieApp.Application.Features.MovieFeature.Commands
{
	public class CreateMovieCommand : IRequest<CreateMovieResponseDto>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Rating { get; set; }
		public int GenreId { get; set; }
		public int DirectorId { get; set; }
	}
}
