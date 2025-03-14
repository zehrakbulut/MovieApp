namespace MovieApp.Application.Dtos.Requests.Reviews
{
	public class CreateReviewRequestDto
	{
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
		public decimal Rating { get; set; }
	}
}
