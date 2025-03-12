using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.CommandHandlers
{
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, UpdateReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public UpdateReviewCommandHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<UpdateReviewResponseDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetByIdAsync(request.Id);
			if (review == null) return new UpdateReviewResponseDto { Success = false };

			await _reviewRepository.UpdateAsync(review);
			return new UpdateReviewResponseDto { Success = true, Comment = review.Comment };
		}
	}
}
