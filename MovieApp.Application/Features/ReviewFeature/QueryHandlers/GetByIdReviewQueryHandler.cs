using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.QueryHandlers
{
	public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQuery, GetByIdReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMapper _mapper;

		public GetByIdReviewQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdReviewResponseDto> Handle(GetByIdReviewQuery request, CancellationToken cancellationToken)
		{
			await _reviewRepository.GetByIdAsync(request.Id);
			return _mapper.Map<GetByIdReviewResponseDto>(request);
		}
	}
}
