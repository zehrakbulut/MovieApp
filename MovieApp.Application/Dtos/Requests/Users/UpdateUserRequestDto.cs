namespace MovieApp.Application.Dtos.Requests.Users
{
	public class UpdateUserRequestDto
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
