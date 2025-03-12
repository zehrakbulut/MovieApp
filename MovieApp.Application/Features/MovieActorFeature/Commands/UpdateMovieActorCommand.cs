using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;

namespace MovieApp.Application.Features.MovieActorFeature.Commands
{
	public class UpdateMovieActorCommand : IRequest<UpdateMovieActorResponseDto>
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
		public string Role { get; set; }
	}
}
