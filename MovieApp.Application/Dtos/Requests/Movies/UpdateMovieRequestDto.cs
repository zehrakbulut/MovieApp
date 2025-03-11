namespace MovieApp.Application.Dtos.Requests.Movies
{
	public class UpdateMovieRequestDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int GenreId { get; set; }
		public int DirectorId { get; set; }
	}
}
