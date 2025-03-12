using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;

namespace MovieApp.Application.Features.MovieFeature.Queries
{
	public class GetAllMovieQuery : IRequest<GetAllMovieResponseDto>
	{
	}
}
