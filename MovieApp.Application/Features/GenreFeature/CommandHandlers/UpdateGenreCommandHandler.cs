using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.CommandHandlers
{
	public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, UpdateGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;

		public UpdateGenreCommandHandler(IGenreRepository genreRepository)
		{
			_genreRepository = genreRepository;
		}

		public async Task<UpdateGenreResponseDto> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = await _genreRepository.GetByIdAsync(request.Id);
			if (genre == null) return new UpdateGenreResponseDto { Success = false };

			genre.Id = request.Id;
			genre.Name = request.Name;

			await _genreRepository.UpdateAsync(genre);
			return new UpdateGenreResponseDto
			{
				Success = true,
				Name = request.Name
			};
		}
	}
}