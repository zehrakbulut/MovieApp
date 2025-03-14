using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.MovieActorFeature.QueryHandlers
{
	public class GetByIdMovieActorQueryHandler : IRequestHandler<GetByIdMovieActorQuery, GetByIdMovieActorResponseDto>
	{
		private readonly IMovieActorRepository _movieActorRepository;
		private readonly IMapper _mapper;

		public GetByIdMovieActorQueryHandler(IMovieActorRepository movieActorRepository, IMapper mapper)
		{
			_movieActorRepository = movieActorRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdMovieActorResponseDto> Handle(GetByIdMovieActorQuery request, CancellationToken cancellationToken)
		{
			var query = await _movieActorRepository.GetByIdAsync(request.MovieId, request.ActorId);

			return new GetByIdMovieActorResponseDto
			{
				MovieId = query.MovieId,
				ActorId = query.ActorId,
				Role = query.Role
			};
		}
	}
}
