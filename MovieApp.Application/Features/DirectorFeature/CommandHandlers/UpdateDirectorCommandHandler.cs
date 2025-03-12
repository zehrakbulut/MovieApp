using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.CommandHandlers
{
	public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, UpdateDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;
		public async Task<UpdateDirectorResponseDto> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
		{
			var director = await _directorRepository.GetByIdAsync(request.Id);

			if (director == null) return new UpdateDirectorResponseDto { Success = false };

			director.Name = request.Name;
			director.Nationality = request.Nationality;

			await _directorRepository.UpdateAsync(director);

			return new UpdateDirectorResponseDto
			{
				Success = true,
				Name = director.Name,
				Nationality = director.Nationality
			};
		}
	}
}
