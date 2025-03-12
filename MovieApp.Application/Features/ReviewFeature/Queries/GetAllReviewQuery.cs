using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Queries
{
	public class GetAllReviewQuery : IRequest<GetAllReviewResponseDto>
	{
	}
}
