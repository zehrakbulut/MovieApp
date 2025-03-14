using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Commands
{
	public class CreateReviewCommand : IRequest<CreateReviewResponseDto>
	{
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
		public decimal Rating { get; set; }
	}
}
