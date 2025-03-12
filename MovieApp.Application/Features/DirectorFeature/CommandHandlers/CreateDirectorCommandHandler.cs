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

		public CreateDirectorCommandHandler(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<CreateDirectorResponseDto> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
		{
			var director = new Director
			{
				Name = request.Name,
				Nationality = request.Nationality,
			};

			await _directorRepository.AddAsync(director);

			return new CreateDirectorResponseDto
			{
				Success = true,
				Name = director.Name,
				Nationality = director.Nationality,
			};
		}
	}
}
