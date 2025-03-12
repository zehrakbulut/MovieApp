using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.CommandHandlers
{
	public class DeleteMovieActorCommandHandler : IRequestHandler<DeleteMovieActorCommand, DeleteMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;

		public DeleteMovieActorCommandHandler(IMovieActorRepository movieActorRepository)
		{
			_movieActorRepository = movieActorRepository;
		}

		public async Task<DeleteMovieActorResponseDto> Handle(DeleteMovieActorCommand request, CancellationToken cancellationToken)
		{
			var movieActor = await _movieActorRepository.GetByIdAsync(request.ActorId, request.MovieId);
			if (movieActor == null) return new DeleteMovieActorResponseDto { Success = false };

			await _movieActorRepository.DeleteAsync(movieActor);
			return new DeleteMovieActorResponseDto { Success = true };
		}
	}
}
