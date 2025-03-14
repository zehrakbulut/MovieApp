using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.QueryHandlers
{
	public class GetTopMovieQueryHandler : IRequestHandler<GetTopMovieQuery, List<GetTopMovieResponseDto>>
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public GetTopMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		public async Task<List<GetTopMovieResponseDto>> Handle(GetTopMovieQuery request, CancellationToken cancellationToken)
		{
			var topMovies = await _movieRepository.GetTopMovieAsync(request.Count);
			return _mapper.Map<List<GetTopMovieResponseDto>>(topMovies);
		}
	}
}
