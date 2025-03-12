using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.CommandHandlers
{
	public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, UpdateMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;

		public UpdateMovieCommandHandler(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public async Task<UpdateMovieResponseDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = await _movieRepository.GetByIdAsync(request.Id);
			if (movie == null) return new UpdateMovieResponseDto { Success = false };

			movie.Id = request.Id;
			movie.Title = request.Title;
			movie.Description = request.Description;
			movie.GenreId = request.GenreId;
			movie.DirectorId = request.DirectorId;

			await _movieRepository.UpdateAsync(movie);
			return new UpdateMovieResponseDto
			{
				Success = true,
				Title = request.Title,
				Description = request.Description
			};
		}
	}
}
