using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.CommandHandlers
{
	public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand, DeleteGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		public DeleteGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<DeleteGenreResponseDto> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = await _genreRepository.GetByIdAsync(request.Id);
			if(genre == null) return new DeleteGenreResponseDto { Success = false };

			await _genreRepository.DeleteAsync(genre);
			return new DeleteGenreResponseDto { Success = true };
		}
	}
}
