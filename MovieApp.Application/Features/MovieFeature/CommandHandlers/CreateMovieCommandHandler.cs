using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.MovieFeature.CommandHandlers
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;

		public CreateMovieCommandHandler(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public async Task<CreateMovieResponseDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = new Movie
			{
				Title = request.Title,
				Description = request.Description,
				GenreId = request.GenreId,
				DirectorId = request.DirectorId
			};

			await _movieRepository.AddAsync(movie);
			return new CreateMovieResponseDto
			{
				Success = true,
				Title = movie.Title,
				Description = movie.Description
			};
		}
	}
}
