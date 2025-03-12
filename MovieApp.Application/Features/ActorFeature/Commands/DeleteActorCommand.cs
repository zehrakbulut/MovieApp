using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;

namespace MovieApp.Application.Features.ActorFeature.Commands
{
	public class DeleteActorCommand : IRequest<DeleteActorResponseDto>
	{
		public int Id { get; set; }
	}
}
