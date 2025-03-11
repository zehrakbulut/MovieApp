namespace MovieApp.Domain.Models.Tables
{
	public class Review
	{
		public int Id { get; set; }
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public decimal Rating { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }
		public Movie Movie { get; set; }
		public User User { get; set; }
	}
}
