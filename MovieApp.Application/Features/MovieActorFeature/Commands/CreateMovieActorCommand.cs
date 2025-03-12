using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;

namespace MovieApp.Application.Features.MovieActorFeature.Commands
{
	public class CreateMovieActorCommand : IRequest<CreateMovieActorResponseDto>
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
		public string Role { get; set; }
	}
}
