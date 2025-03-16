using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Queries
{
	public class GetAllReviewQuery : IRequest<GetAllReviewResponseDto>
	{
		public bool MostReviewed { get; set; } = true;
		public int Count { get; set; } = 3;
	}
}
