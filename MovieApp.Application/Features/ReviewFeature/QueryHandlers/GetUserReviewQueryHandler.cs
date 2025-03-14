using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.ReviewFeature.QueryHandlers
{
	public class GetUserReviewQueryHandler : IRequestHandler<GetUserReviewQuery, GetUserReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public GetUserReviewQueryHandler(IReviewRepository reviewRepository, IUserRepository userRepository, IMapper mapper)
		{
			_reviewRepository = reviewRepository;
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<GetUserReviewResponseDto> Handle(GetUserReviewQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetByIdAsync(request.UserId);
			if (users == null)
			{
				throw new Exception("Kullanıcı bulunamadı.");
			}

			var reviews = await _reviewRepository.GetUserReviewAsync(request.UserId);

			var response = _mapper.Map<GetUserReviewResponseDto>(reviews);
			return response;
		}
	}
}
