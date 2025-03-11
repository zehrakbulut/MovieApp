namespace MovieApp.Domain.Models.Tables
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public decimal Rating { get; set; }
		public int Duration { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string Description { get; set; }
		public int GenreId { get; set; }
		public int DirectorId { get; set; }
		public Genre Genre { get; set; }
		public Director Director { get; set; }

		public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
		public ICollection<Review> Reviews { get; set; }
	}
}
