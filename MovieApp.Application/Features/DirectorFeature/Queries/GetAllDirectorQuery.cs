using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;

namespace MovieApp.Application.Features.DirectorFeature.Queries
{
	public class GetAllDirectorQuery : IRequest<GetAllDirectorResponseDto>
	{
	}
}
