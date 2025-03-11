namespace MovieApp.Domain.Models.Tables
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime CreatedAt { get; set; }

		public ICollection<Review> Reviews { get; set; } = new List<Review>();
	}
}
