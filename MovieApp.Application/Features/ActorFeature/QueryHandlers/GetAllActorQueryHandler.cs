using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.QueryHandlers
{
	public class GetAllActorQueryHandler : IRequestHandler<GetAllActorQuery, GetAllActorReponseDto>
	{
		private readonly IActorRepository _actorRepository;

		public GetAllActorQueryHandler(IActorRepository actorRepository)
		{
			_actorRepository = actorRepository;
		}

		public async Task<GetAllActorReponseDto> Handle(GetAllActorQuery request, CancellationToken cancellationToken)
		{
			var actors = await _actorRepository.GetAllAsync();

			var actorResponse = actors.Select(actor => new GetByIdActorResponseDto
			{
				Id = actor.Id,
				Name = actor.Name,
				Nationality = actor.Nationality
			}).ToList();

			return new GetAllActorReponseDto { Actors = actorResponse };
		}
	}
}
