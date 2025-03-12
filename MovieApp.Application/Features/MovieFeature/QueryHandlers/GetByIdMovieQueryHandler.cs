using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieFeature.QueryHandlers
{
	public class GetByIdMovieQueryHandler : IRequestHandler<GetByIdMovieQuery, GetByIdMovieResponseDto>
	{
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public GetByIdMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper)
		{
			_movieRepository = movieRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdMovieResponseDto> Handle(GetByIdMovieQuery request, CancellationToken cancellationToken)
		{
			await _movieRepository.GetByIdAsync(request.Id);

			return _mapper.Map<GetByIdMovieResponseDto>(request);
		}
	}
}
