namespace MovieApp.Application.Dtos.Requests.MovieActors
{
	public class CreateMovieActorRequestDto
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
		public string Role { get; set; }
	}
}
