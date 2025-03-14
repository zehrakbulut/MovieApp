using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.CommandHandlers
{
	public class DeleteMovieActorCommandHandler : IRequestHandler<DeleteMovieActorCommand, DeleteMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;
		private readonly IMapper _mapper;

		public DeleteMovieActorCommandHandler(IMovieActorRepository movieActorRepository, IMapper mapper)
		{
			_movieActorRepository = movieActorRepository;
			_mapper = mapper;
		}

		public async Task<DeleteMovieActorResponseDto> Handle(DeleteMovieActorCommand request, CancellationToken cancellationToken)
		{
			var movieActor = await _movieActorRepository.GetByIdAsync(request.MovieId, request.ActorId);
			if (movieActor == null) return new DeleteMovieActorResponseDto { Success = false };

			await _movieActorRepository.DeleteAsync(movieActor);
			return new DeleteMovieActorResponseDto { Success = true };
		}
	}
}
