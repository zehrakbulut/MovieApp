using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Commands
{
	public class UpdateReviewCommand : IRequest<UpdateReviewResponseDto>
	{
		public int Id { get; set; }
		public string Comment { get; set; }
		public decimal Rating { get; set; }
		public int MovieId { get; set; }
		public int UserId { get; set; }
	}
}
