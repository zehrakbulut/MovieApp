using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;

namespace MovieApp.Application.Features.MovieFeature.Queries
{
	public class GetByIdMovieQuery : IRequest<GetByIdMovieResponseDto>
	{
		public int Id { get; set; }
	}
}
