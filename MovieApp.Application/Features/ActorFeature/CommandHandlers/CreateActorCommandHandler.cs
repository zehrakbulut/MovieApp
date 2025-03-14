using AutoMapper;
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
		private readonly IMapper _mapper;

		public CreateActorCommandHandler(IActorRepository actorRepository, IMapper mapper)
		{
			_actorRepository = actorRepository;
			_mapper = mapper;
		}

		public async Task<CreateActorResponseDto> Handle(CreateActorCommand request, CancellationToken cancellationToken)
		{
			var actor = _mapper.Map<Actor>(request);
			await _actorRepository.AddAsync(actor);
			return new CreateActorResponseDto
			{
				IsSuccess = true,
				Name = actor.Name,
				Nationality = actor.Nationality
			};

		}
	}
}
