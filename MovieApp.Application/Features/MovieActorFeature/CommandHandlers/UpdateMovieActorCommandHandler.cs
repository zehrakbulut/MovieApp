using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.CommandHandlers
{
	public class UpdateMovieActorCommandHandler : IRequestHandler<UpdateMovieActorCommand, UpdateMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;
		private readonly IMapper _mapper;

		public UpdateMovieActorCommandHandler(IMovieActorRepository movieActorRepository, IMapper mapper)
		{
			_movieActorRepository = movieActorRepository;
			_mapper = mapper;
		}

		public async Task<UpdateMovieActorResponseDto> Handle(UpdateMovieActorCommand request, CancellationToken cancellationToken)
		{
			var movieActor = await _movieActorRepository.GetByIdAsync(request.ActorId, request.MovieId);
			if (movieActor == null) return new UpdateMovieActorResponseDto { Success = false };

			_mapper.Map(request, movieActor);
			await _movieActorRepository.UpdateAsync(movieActor);
			return _mapper.Map<UpdateMovieActorResponseDto>(movieActor);
		}
	}
}
