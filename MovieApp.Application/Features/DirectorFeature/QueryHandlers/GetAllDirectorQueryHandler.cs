using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.QueryHandlers
{
	public class GetAllDirectorQueryHandler : IRequestHandler<GetAllDirectorQuery, GetAllDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;
		private readonly IMapper _mapper;

		public GetAllDirectorQueryHandler(IDirectorRepository directorRepository, IMapper mapper)
		{
			_directorRepository = directorRepository;
			_mapper = mapper;
		}

		public async Task<GetAllDirectorResponseDto> Handle(GetAllDirectorQuery request, CancellationToken cancellationToken)
		{
			var directors = await _directorRepository.GetAllAsync();

			var directorResponse = _mapper.Map<IEnumerable<GetByIdDirectorResponseDto>>(directors).ToList();
			return new GetAllDirectorResponseDto { Directors = directorResponse };
		}
	}
}
