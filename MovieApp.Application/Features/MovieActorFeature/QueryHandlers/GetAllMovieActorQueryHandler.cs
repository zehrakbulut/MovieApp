using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.QueryHandlers
{
	public class GetAllMovieActorQueryHandler : IRequestHandler<GetAllMovieActorQuery, GetAllMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;
		private readonly IMapper _mapper;

		public GetAllMovieActorQueryHandler(IMovieActorRepository movieActorRepository, IMapper mapper)
		{
			_movieActorRepository = movieActorRepository;
			_mapper = mapper;
		}

		public async Task<GetAllMovieActorResponseDto> Handle(GetAllMovieActorQuery request, CancellationToken cancellationToken)
		{
			var movieActors = await _movieActorRepository.GetAllAsync();
			var movieActorResponse = _mapper.Map<IEnumerable<GetByIdMovieActorResponseDto>>(movieActors).ToList();

			return new GetAllMovieActorResponseDto { MovieActors = movieActorResponse };
		}
	}
}
