using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;

namespace MovieApp.Application.Features.MovieFeature.Queries
{
	public class GetTopMovieQuery : IRequest<List<GetTopMovieResponseDto>>
	{
		public int Count { get; set; }
	}
}
