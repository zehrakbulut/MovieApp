using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.CommandHandlers
{
	public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, UpdateDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;
		private readonly IMapper _mapper;

		public UpdateDirectorCommandHandler(IDirectorRepository directorRepository, IMapper mapper)
		{
			_directorRepository = directorRepository;
			_mapper = mapper;
		}

		public async Task<UpdateDirectorResponseDto> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
		{
			var director = await _directorRepository.GetByIdAsync(request.Id);

			if (director == null) return new UpdateDirectorResponseDto { Success = false };

			_mapper.Map(request,director);
			await _directorRepository.UpdateAsync(director);
			return _mapper.Map<UpdateDirectorResponseDto>(director);
		}
	}
}
