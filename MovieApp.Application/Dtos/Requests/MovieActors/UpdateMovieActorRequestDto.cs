namespace MovieApp.Application.Dtos.Requests.MovieActors
{
	public class UpdateMovieActorRequestDto
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
		public string Role { get; set; }
	}
}
