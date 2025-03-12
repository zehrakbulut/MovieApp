using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.CommandHandlers
{
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, UpdateReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

		public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<UpdateReviewResponseDto> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetByIdAsync(request.Id);
			if (review == null) return new UpdateReviewResponseDto { Success = false };

			_mapper.Map(request, review);	
			await _reviewRepository.UpdateAsync(review);
			return _mapper.Map<UpdateReviewResponseDto>(review);
		}
	}
}
