using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;

namespace MovieApp.Application.Features.MovieActorFeature.Commands
{
	public class DeleteMovieActorCommand : IRequest<DeleteMovieActorResponseDto>
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
	}
}
