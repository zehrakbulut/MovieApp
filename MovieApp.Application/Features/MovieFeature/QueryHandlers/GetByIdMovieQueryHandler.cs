using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.QueryHandlers
{
	public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;

		public GetByIdMovieQueryHandler(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public async Task<GetByIdMovieResponseDto> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
		{
			await _movieRepository.GetByIdAsync(request.Id);
			return new GetByIdMovieResponseDto
			{
				Id = request.Id,
				Title = request.Title,
				DirectorId = request.DirectorId,
				GenreId = request.GenreId
			};
		}
	}
}
