using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.DirectorFeature.QueryHandlers
{
	public class GetByIdDirectorQueryHandler : IRequestHandler<GetByIdDirectorQuery, GetByIdDirectorResponseDto>
	{
		private readonly IDirectorRepository _directorRepository;

		public GetByIdDirectorQueryHandler(IDirectorRepository directorRepository)
		{
			_directorRepository = directorRepository;
		}

		public async Task<GetByIdDirectorResponseDto> Handle(GetByIdDirectorQuery request, CancellationToken cancellationToken)
		{
			await _directorRepository.GetByIdAsync(request.Id);
			return new GetByIdDirectorResponseDto
			{
				Id = request.Id,
				Name = request.Name,
				Nationality = request.Nationality
			};
		}
	}
}
