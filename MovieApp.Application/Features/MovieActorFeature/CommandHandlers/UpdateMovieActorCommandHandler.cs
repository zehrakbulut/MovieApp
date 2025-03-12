using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.CommandHandlers
{
	public class UpdateMovieActorCommandHandler : IRequestHandler<UpdateMovieActorCommand, UpdateMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;

		public UpdateMovieActorCommandHandler(IMovieActorRepository movieActorRepository)
		{
			_movieActorRepository = movieActorRepository;
		}

		public async Task<UpdateMovieActorResponseDto> Handle(UpdateMovieActorCommand request, CancellationToken cancellationToken)
		{
			var movieActor = await _movieActorRepository.GetByIdAsync(request.ActorId, request.MovieId);
			if (movieActor == null) return new UpdateMovieActorResponseDto { Success = false };

			await _movieActorRepository.UpdateAsync(movieActor);
			return new UpdateMovieActorResponseDto { Success = true, Role = request.Role };
		}
	}
}
