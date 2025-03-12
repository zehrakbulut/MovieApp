using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Commands
{
	public class DeleteReviewCommand : IRequest<DeleteReviewResponseDto>
	{
		public int Id { get; set; }
	}
}
