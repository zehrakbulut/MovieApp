namespace MovieApp.Domain.Models.Tables
{
	public class Actor
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }

		public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
	}
}
