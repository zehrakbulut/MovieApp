using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.MovieActorFeature.CommandHandlers
{
	public class CreateMovieActorCommandHandler : IRequestHandler<CreateMovieActorCommand, CreateMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;

		public CreateMovieActorCommandHandler(IMovieActorRepository movieActorRepository)
		{
			_movieActorRepository = movieActorRepository;
		}

		public async Task<CreateMovieActorResponseDto> Handle(CreateMovieActorCommand request, CancellationToken cancellationToken)
		{
			var movieActor = new MovieActor
			{
				MovieId = request.MovieId,
				ActorId = request.ActorId,
				Role = request.Role
			};

			await _movieActorRepository.AddAsync(movieActor);
			return new CreateMovieActorResponseDto { Success = true, Role = request.Role };
		}
	}
}
