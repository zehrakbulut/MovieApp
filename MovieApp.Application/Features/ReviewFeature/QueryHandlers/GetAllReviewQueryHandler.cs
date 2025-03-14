using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.QueryHandlers
{
	public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, GetAllReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

		public GetAllReviewQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<GetAllReviewResponseDto> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
		{
			var reviews = await _reviewRepository.GetAllAsync();
			var reviewResponse = _mapper.Map<IEnumerable<GetByIdReviewResponseDto>>(reviews).ToList();

			return new GetAllReviewResponseDto { Reviews = reviewResponse };
		}
	}
}
