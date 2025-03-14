using AutoMapper;
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
		private readonly IMapper _mapper;

		public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<CreateReviewResponseDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			var review = _mapper.Map<Review>(request);
			await _reviewRepository.AddAsync(review);
			return new CreateReviewResponseDto
			{
				Success = true,
				Comment = review.Comment
			};
		}
	}
}
