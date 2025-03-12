using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.CommandHandlers
{
	public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, DeleteMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;

		public DeleteMovieCommandHandler(IMovieRepository movieRepository)
		{
			_movieRepository = movieRepository;
		}

		public async Task<DeleteMovieResponseDto> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = await _movieRepository.GetByIdAsync(request.Id);
			if (movie == null) return new DeleteMovieResponseDto { Success = false };

			await _movieRepository.DeleteAsync(movie);
			return new DeleteMovieResponseDto { Success = true};
		}
	}
}
