using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;

namespace MovieApp.Application.Features.ReviewFeature.Queries
{
	public class GetByIdReviewQuery : IRequest<GetByIdReviewResponseDto>
	{
		public int Id { get; set; }
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
	}
}
