using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.CommandHandlers
{
	public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, DeleteReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

		public DeleteReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<DeleteReviewResponseDto> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetByIdAsync(request.Id);
			if (review == null) return new DeleteReviewResponseDto { Success = false };

			await _reviewRepository.DeleteAsync(review);
			return new DeleteReviewResponseDto { Success = true };
		}
	}
}
