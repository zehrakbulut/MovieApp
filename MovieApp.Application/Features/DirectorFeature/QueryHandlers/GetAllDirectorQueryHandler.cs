using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.QueryHandlers
{
	public class GetAllDirectorQueryHandler : IRequestHandler<GetAllDirectorQuery, GetAllDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;

		public GetAllDirectorQueryHandler(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<GetAllDirectorResponseDto> Handle(GetAllDirectorQuery request, CancellationToken cancellationToken)
		{
			var directors = await _directorRepository.GetAllAsync();

			var directorResponse = directors.Select(director => new GetByIdDirectorResponseDto
			{
				Id = director.Id,
				Name = director.Name,
				Nationality = director.Nationality
			}).ToList();

			return new GetAllDirectorResponseDto { Directors = directorResponse };
		}
	}
}
