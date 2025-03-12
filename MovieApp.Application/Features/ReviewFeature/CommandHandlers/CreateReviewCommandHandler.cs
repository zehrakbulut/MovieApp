using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.ReviewFeature.CommandHandlers
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, CreateReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public CreateReviewCommandHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<CreateReviewResponseDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			var review = new Review
			{
				Comment = request.Comment,
				MovieId = request.MovieId,
				UserId = request.UserId,
			};

			await _reviewRepository.AddAsync(review);
			return new CreateReviewResponseDto
			{
				Success = true,
				Comment = request.Comment
			};
		}
	}
}
