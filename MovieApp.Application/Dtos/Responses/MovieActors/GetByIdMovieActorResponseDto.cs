namespace MovieApp.Application.Dtos.Responses.MovieActors
{
	public class GetByIdMovieActorResponseDto
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
		public string Role { get; set; }
	}
}
