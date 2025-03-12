using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.DirectorFeature.CommandHandlers
{
	public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, CreateDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;
		private readonly IMapper _mapper;

		public CreateDirectorCommandHandler(IDirectorRepository directorRepository, IMapper mapper)
		{
			_directorRepository = directorRepository;
			_mapper = mapper;
		}

		public async Task<CreateDirectorResponseDto> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
		{
			var director = _mapper.Map<Director>(request);
			await _directorRepository.AddAsync(director);
			return _mapper.Map<CreateDirectorResponseDto>(request);
		}
	}
}
