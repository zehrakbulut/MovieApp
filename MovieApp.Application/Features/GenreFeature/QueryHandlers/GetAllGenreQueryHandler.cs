using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.QueryHandlers
{
	public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQuery, GetAllGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;

		public GetAllGenreQueryHandler(IGenreRepository genreRepository)
		{
			_genreRepository = genreRepository;
		}

		public async Task<GetAllGenreResponseDto> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
		{
			var genres = await _genreRepository.GetAllAsync();

			var genreResponse = genres.Select(genre => new GetByIdGenreResponseDto
			{
				Id = genre.Id,
				Name = genre.Name
			}).ToList();

			return new GetAllGenreResponseDto { Genres = genreResponse };
		}
	}
}
