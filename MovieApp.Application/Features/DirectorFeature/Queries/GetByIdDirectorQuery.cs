using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;

namespace MovieApp.Application.Features.DirectorFeature.Queries
{
	public class GetByIdDirectorQuery : IRequest<GetByIdDirectorResponseDto>
	{
		public int Id { get; set; }
	}
}
