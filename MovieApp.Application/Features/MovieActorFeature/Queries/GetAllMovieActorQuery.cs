using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;

namespace MovieApp.Application.Features.MovieActorFeature.Queries
{
	public class GetAllMovieActorQuery : IRequest<GetAllMovieActorResponseDto>
	{
		public string Cast {  get; set; }
	}
}
