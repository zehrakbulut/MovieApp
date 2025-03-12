using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ActorFeature.QueryHandlers
{
	public class GetByIdActorQueryHandler : IRequestHandler<GetByIdActorQuery, GetByIdActorResponseDto>
	{
		private readonly IActorRepository _actorRepository;

		public GetByIdActorQueryHandler(IActorRepository actorRepository)
		{
			_actorRepository = actorRepository;
		}

		public async Task<GetByIdActorResponseDto> Handle(GetByIdActorQuery request, CancellationToken cancellationToken)
		{
			 await _actorRepository.GetByIdAsync(request.Id);

			return new GetByIdActorResponseDto
			{
				Id = request.Id,
				Name = request.Name,
				Nationality = request.Nationality,
			};
		}
	}
}
