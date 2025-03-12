using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.GenreFeature.CommandHandlers
{
	public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, UpdateGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		public UpdateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<UpdateGenreResponseDto> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = await _genreRepository.GetByIdAsync(request.Id);
			if (genre == null) return new UpdateGenreResponseDto { Success = false };

			_mapper.Map(request, genre);
			await _genreRepository.UpdateAsync(genre);
			return _mapper.Map<UpdateGenreResponseDto>(genre);
		}
	}
}