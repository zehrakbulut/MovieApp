using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.QueryHandlers
{
	public class GetAllActorQueryHandler : IRequestHandler<GetAllActorQuery, GetAllActorReponseDto>
	{
		private readonly IActorRepository _actorRepository;
		private readonly IMapper _mapper;

		public GetAllActorQueryHandler(IActorRepository actorRepository, IMapper mapper)
		{
			_actorRepository = actorRepository;
			_mapper = mapper;
		}

		public async Task<GetAllActorReponseDto> Handle(GetAllActorQuery request, CancellationToken cancellationToken)
		{
			var actors = await _actorRepository.GetAllAsync();

			var actorResponse = _mapper.Map<IEnumerable<GetByIdActorResponseDto>>(actors).ToList();
			return new GetAllActorReponseDto { Actors = actorResponse };
		}
	}
}
