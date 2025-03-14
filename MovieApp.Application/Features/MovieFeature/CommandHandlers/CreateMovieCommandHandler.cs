using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.MovieFeature.CommandHandlers
{
	public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		public async Task<CreateMovieResponseDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = _mapper.Map<Movie>(request);
			await _movieRepository.AddAsync(movie);
			return new CreateMovieResponseDto
			{
				Success = true,
				Description = movie.Description,
				Title = movie.Title,
				Rating = movie.Rating
			};
		}
	}
}
