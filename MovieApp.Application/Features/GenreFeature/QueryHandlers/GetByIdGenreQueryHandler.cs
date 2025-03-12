using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.QueryHandlers
{
	public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQuery, GetByIdGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;

		public GetByIdGenreQueryHandler(IGenreRepository genreRepository)
		{
			_genreRepository = genreRepository;
		}

		public async Task<GetByIdGenreResponseDto> Handle(GetByIdGenreQuery request, CancellationToken cancellationToken)
		{
			await _genreRepository.GetByIdAsync(request.Id);
			return new GetByIdGenreResponseDto
			{
				Id = request.Id,
				Name = request.Name
			};
		}
	}
}
