using AutoMapper;
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
		private readonly IMapper _mapper;

		public CreateMovieActorCommandHandler(IMovieActorRepository movieActorRepository, IMapper mapper)
		{
			_movieActorRepository = movieActorRepository;
			_mapper = mapper;
		}

		public async Task<CreateMovieActorResponseDto> Handle(CreateMovieActorCommand request, CancellationToken cancellationToken)
		{
			var movieActor = _mapper.Map<MovieActor>(request);
			await _movieActorRepository.AddAsync(movieActor);
			return _mapper.Map<CreateMovieActorResponseDto>(movieActor);
		}
	}
}
