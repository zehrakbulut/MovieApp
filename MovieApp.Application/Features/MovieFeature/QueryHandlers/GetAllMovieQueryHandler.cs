using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.QueryHandlers
{
	public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQuery, GetAllMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;

		public GetAllMovieQueryHandler(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public async Task<GetAllMovieResponseDto> Handle(GetAllMovieQuery request, CancellationToken cancellationToken)
		{
			var movies = await _movieRepository.GetAllAsync();

			var movieResponse = movies.Select(movie => new GetByIdMovieResponseDto
			{
				Id = movie.Id,
				DirectorId = movie.DirectorId,
				GenreId = movie.GenreId,
				Title = movie.Title
			}).ToList();

			return new GetAllMovieResponseDto { Movies = movieResponse };
		}
	}
}
