using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.CommandHandlers
{
	public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, UpdateActorResponseDto>
	{
		private readonly IActorRepository _actorRepository;
		private readonly IMapper _mapper;

		public UpdateActorCommandHandler(IActorRepository actorRepository, IMapper mapper)
		{
			_actorRepository = actorRepository;
			_mapper = mapper;
		}

		public async Task<UpdateActorResponseDto> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
		{
			var actor = await _actorRepository.GetByIdAsync(request.Id);

			if (actor == null) return new UpdateActorResponseDto { Success = false };

			_mapper.Map(request, actor);
			await _actorRepository.UpdateAsync(actor);
			return _mapper.Map<UpdateActorResponseDto>(actor);

		}
	}
}
