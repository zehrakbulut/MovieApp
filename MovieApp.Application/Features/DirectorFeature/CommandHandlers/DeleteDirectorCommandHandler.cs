﻿using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.CommandHandlers
{
	public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, DeleteDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;

		public DeleteDirectorCommandHandler(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<DeleteDirectorResponseDto> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
		{
			var director = await _directorRepository.GetByIdAsync(request.Id);

			if (director == null) return new DeleteDirectorResponseDto { Success = false };

			await _directorRepository.DeleteAsync(director);
			return new DeleteDirectorResponseDto { Success = true };
		}
	}
}
