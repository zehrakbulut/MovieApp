using MediatR;
using MovieApp.Application.Dtos.Responses.Genres;

namespace MovieApp.Application.Features.GenreFeature.Queries
{
	public class GetByIdGenreQuery : IRequest<GetByIdGenreResponseDto>
	{
		public int Id { get; set; }
	}
}
