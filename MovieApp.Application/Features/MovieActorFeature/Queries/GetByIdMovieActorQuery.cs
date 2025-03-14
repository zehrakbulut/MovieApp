using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;

namespace MovieApp.Application.Features.MovieActorFeature.Queries
{
	public class GetByIdMovieActorQuery : IRequest<GetByIdMovieActorResponseDto>
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
	}
}
