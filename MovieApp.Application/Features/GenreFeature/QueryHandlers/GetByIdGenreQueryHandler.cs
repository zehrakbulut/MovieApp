using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.QueryHandlers
{
	public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQuery, GetByIdGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;
		public GetByIdGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdGenreResponseDto> Handle(GetByIdGenreQuery request, CancellationToken cancellationToken)
		{
			await _genreRepository.GetByIdAsync(request.Id);

			return _mapper.Map<GetByIdGenreResponseDto>(request);
		}
	}
}
