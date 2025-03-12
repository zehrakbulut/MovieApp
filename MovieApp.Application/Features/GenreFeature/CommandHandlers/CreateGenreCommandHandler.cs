using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.GenreFeature.CommandHandlers
{
	public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, CreateGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;

		public CreateGenreCommandHandler(IGenreRepository genreRepository)
		{
			_genreRepository = genreRepository;
		}

		public async Task<CreateGenreResponseDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = new Genre
			{
				Name = request.Name
			};

			await _genreRepository.AddAsync(genre);

			return new CreateGenreResponseDto
			{
				Success = true,
				Name = genre.Name
			};
		}
	}
}
