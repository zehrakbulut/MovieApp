using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.QueryHandlers
{
	public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, GetAllReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetAllReviewQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<GetAllReviewResponseDto> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
		{
			var reviews = await _reviewRepository.GetAllAsync();
			var reviewResponse = reviews.Select(review => new GetByIdReviewResponseDto
			{
				Id = review.Id,
				Comment = review.Comment,
				MovieId = review.MovieId,
				UserId = review.UserId
			}).ToList();

			return new GetAllReviewResponseDto { Reviews = reviewResponse };
		}
	}
}
