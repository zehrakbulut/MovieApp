using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.CommandHandlers
{
	public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, UpdateActorResponseDto>
	{
		private readonly IActorRepository _actorRepository;

		public UpdateActorCommandHandler(IActorRepository actorRepository)
		{
			_actorRepository = actorRepository;
		}

		public async Task<UpdateActorResponseDto> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
		{
			var actor = await _actorRepository.GetByIdAsync(request.Id);

			if (actor == null) return new UpdateActorResponseDto { Success = false };
					
			actor.Name = request.Name;
			actor.Nationality = request.Nationality;
			actor.BirthDate = request.BirthDate;

			await _actorRepository.UpdateAsync(actor);
			return new UpdateActorResponseDto
			{
				Success = true,
				Name = actor.Name,
				Nationality = actor.Nationality
			};

		}
	}
}
