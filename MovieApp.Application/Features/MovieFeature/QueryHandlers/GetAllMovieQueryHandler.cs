using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.QueryHandlers
{
	public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, GetAllMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public GetAllMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		public async Task<GetAllMovieResponseDto> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
		{
			var movies = await _movieRepository.GetAllAsync();

			var movieResponse = _mapper.Map<IEnumerable<GetByIdMovieResponseDto>>(movies).ToList();
			return new GetAllMovieResponseDto { Movies = movieResponse };
		}
	}
}
