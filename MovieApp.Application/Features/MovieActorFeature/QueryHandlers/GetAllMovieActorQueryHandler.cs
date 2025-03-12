using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.QueryHandlers
{
	public class GetAllMovieActorQueryHandler : IRequestHandler<GetAllMovieActorQuery, GetAllMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;

		public GetAllMovieActorQueryHandler(IMovieActorRepository movieActorRepository)
		{
			_movieActorRepository = movieActorRepository;
		}

		public async Task<GetAllMovieActorResponseDto> Handle(GetAllMovieActorQuery request, CancellationToken cancellationToken)
		{
			var movieActors = await _movieActorRepository.GetAllAsync();

			var movieActorResponse = movieActors.Select(movieActor => new GetByIdMovieActorResponseDto
			{
				ActorId = movieActor.ActorId,
				MovieId = movieActor.MovieId,
				Role = movieActor.Role
			}).ToList();

			return new GetAllMovieActorResponseDto { MovieActors = movieActorResponse };
		}
	}
}
