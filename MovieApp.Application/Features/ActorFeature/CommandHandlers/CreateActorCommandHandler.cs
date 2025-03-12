using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.ActorFeature.CommandHandlers
{
	public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, CreateActorResponseDto>
	{
		private readonly IActorRepository _actorRepository;

		public CreateActorCommandHandler(IActorRepository actorRepository)
		{
			_actorRepository = actorRepository;
		}

		public async Task<CreateActorResponseDto> Handle(CreateActorCommand request, CancellationToken cancellationToken)
		{
			var actor = new Actor
			{
				Name = request.Name,
				Nationality = request.Nationality,
				BirthDate = request.BirthDate
			};

			await _actorRepository.AddAsync(actor);

			return new CreateActorResponseDto
			{
				Success = true,
				Name = actor.Name,
				Nationality = actor.Nationality,
			};
		}
	}
}
