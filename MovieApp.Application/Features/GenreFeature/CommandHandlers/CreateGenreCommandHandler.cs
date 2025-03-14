using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.GenreFeature.CommandHandlers
{
	public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, CreateGenreResponseDto>
	{
		private readonly IGenreRepository _genreRepository;
		private readonly IMapper _mapper;

		public CreateGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<CreateGenreResponseDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
		{
			var genre = _mapper.Map<Genre>(request);
			await _genreRepository.AddAsync(genre);
			return new CreateGenreResponseDto
			{
				IsSuccess = true,
				Name = genre.Name
			};
		}
	}
}
