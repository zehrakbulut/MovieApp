namespace MovieApp.Domain.Models.Tables
{
	public class Director
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }

		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
	}
}
