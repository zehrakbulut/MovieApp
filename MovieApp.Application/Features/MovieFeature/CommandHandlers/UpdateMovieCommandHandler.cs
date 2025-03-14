using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.CommandHandlers
{
	public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, UpdateMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		public async Task<UpdateMovieResponseDto> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
		{
			var movie = await _movieRepository.GetByIdAsync(request.Id);

			if (movie == null) return new UpdateMovieResponseDto { Success = false };

			_mapper.Map(request,movie);
			await _movieRepository.UpdateAsync(movie);
			return new UpdateMovieResponseDto
			{
				Success = true,
				Title = movie.Title,
				Description = movie.Description
			};
		}
	}
}
