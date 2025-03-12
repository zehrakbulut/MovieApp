using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.QueryHandlers
{
	public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQuery, GetByIdReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetByIdReviewQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<GetByIdReviewResponseDto> Handle(GetByIdReviewQuery request, CancellationToken cancellationToken)
		{
			await _reviewRepository.GetByIdAsync(request.Id);
			return new GetByIdReviewResponseDto
			{
				Id = request.Id,
				Comment = request.Comment,
				MovieId = request.MovieId,
				UserId = request.UserId
			};
		}
	}
}
