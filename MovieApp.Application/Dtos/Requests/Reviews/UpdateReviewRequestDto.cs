namespace MovieApp.Application.Dtos.Requests.Reviews
{
	public class UpdateReviewRequestDto
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public int MovieId { get; set; }
		public int UserId { get; set; }
	}
}
