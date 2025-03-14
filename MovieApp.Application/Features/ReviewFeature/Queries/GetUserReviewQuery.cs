using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Queries
{
	public class GetUserReviewQuery : IRequest<GetUserReviewResponseDto>
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Description { get; set; }
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
		public decimal Rating { get; set; }
		public string Title { get; set; }
	}
}
