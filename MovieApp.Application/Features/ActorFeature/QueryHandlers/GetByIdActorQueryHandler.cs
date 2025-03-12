using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.QueryHandlers
{
	public class GetByIdActorQueryHandler : IRequestHandler<GetByIdActorQuery, GetByIdActorResponseDto>
	{
		private readonly IActorRepository _actorRepository;
		private readonly IMapper _mapper;

		public GetByIdActorQueryHandler(IActorRepository actorRepository, IMapper mapper = null)
		{
			_actorRepository = actorRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdActorResponseDto> Handle(GetByIdActorQuery request, CancellationToken cancellationToken)
		{
			 await _actorRepository.GetByIdAsync(request.Id);

			return _mapper.Map<GetByIdActorResponseDto>(request);
		}
	}
}
