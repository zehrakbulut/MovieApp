namespace MovieApp.Application.Dtos.Requests.Actors
{
	public class UpdateActorRequestDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
