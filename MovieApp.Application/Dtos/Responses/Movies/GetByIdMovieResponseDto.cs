namespace MovieApp.Application.Dtos.Responses.Movies
{
	public class GetByIdMovieResponseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int GenreId { get; set; }
		public int DirectorId { get; set; }
	}
}
