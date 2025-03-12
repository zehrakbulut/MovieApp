using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.QueryHandlers
{
	public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQuery, GetAllGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		public GetAllGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<GetAllGenreResponseDto> Handle(GetAllGenreQuery request, CancellationToken cancellationToken)
		{
			var genres = await _genreRepository.GetAllAsync();

			var genreResponse = _mapper.Map<IEnumerable<GetByIdGenreResponseDto>>(genres).ToList();
			return new GetAllGenreResponseDto { Genres = genreResponse };
		}
	}
}
