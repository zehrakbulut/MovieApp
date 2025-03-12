using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;

namespace MovieApp.Application.Features.GenreFeature.Queries
{
	public class GetAllGenreQuery : IRequest<GetAllGenreResponseDto>
	{
	}
}
