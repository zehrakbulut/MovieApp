using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.QueryHandlers
{
	public class GetByIdMovieActorQueryHandler : IRequestHandler<GetByIdMovieActorQuery, GetByIdMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;

		public GetByIdMovieActorQueryHandler(IMovieActorRepository movieActorRepository)
		{
			_movieActorRepository = movieActorRepository;
		}

		public async Task<GetByIdMovieActorResponseDto> Handle(GetByIdMovieActorQuery request, CancellationToken cancellationToken)
		{
			await _movieActorRepository.GetByIdAsync(request.MovieId, request.ActorId);
			return new GetByIdMovieActorResponseDto
			{
				ActorId = request.ActorId,
				MovieId = request.MovieId,
				Role = request.Role
			};
		}
	}
}
