using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.CommandHandlers
{
	public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, DeleteActorResponseDto>
	{
		private readonly IActorRepository _actorRepository;

		public DeleteActorCommandHandler(IActorRepository actorRepository)
		{
			_actorRepository = actorRepository;
		}

		public async Task<DeleteActorResponseDto> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
		{
			var actor = await _actorRepository.GetByIdAsync(request.Id);
			
			if (actor == null) return new DeleteActorResponseDto { Success = false };

			await _actorRepository.DeleteAsync(actor);
			return new DeleteActorResponseDto { Success = true };
		}
	}
}
