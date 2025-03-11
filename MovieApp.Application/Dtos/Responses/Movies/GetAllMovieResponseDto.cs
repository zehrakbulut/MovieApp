namespace MovieApp.Application.Dtos.Responses.Movies
{
	public class GetAllMovieResponseDto
	{
		public List<GetByIdMovieResponseDto> Movies { get; set; }
	}
}
