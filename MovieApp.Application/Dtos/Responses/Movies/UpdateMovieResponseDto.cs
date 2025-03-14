namespace MovieApp.Application.Dtos.Responses.Movies
{
	public class UpdateMovieResponseDto
	{
		public bool Success { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Rating { get; set; }
	}
}
