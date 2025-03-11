namespace MovieApp.Application.Dtos.Requests.Actors
{
	public class CreateActorRequestDto
	{
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
