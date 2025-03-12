using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.QueryHandlers
{
	public class GetByIdDirectorQueryHandler : IRequestHandler<GetByIdDirectorQuery, GetByIdDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;
		private readonly IMapper _mapper;

		public GetByIdDirectorQueryHandler(IDirectorRepository directorRepository, IMapper mapper)
		{
			_directorRepository = directorRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdDirectorResponseDto> Handle(GetByIdDirectorQuery request, CancellationToken cancellationToken)
		{
			await _directorRepository.GetByIdAsync(request.Id);
			return _mapper.Map<GetByIdDirectorResponseDto>(request);
		}
	}
}
