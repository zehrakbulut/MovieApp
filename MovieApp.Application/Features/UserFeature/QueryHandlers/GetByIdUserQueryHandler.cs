using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.QueryHandlers
{
	public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponseDto>
	{
		private readonly IUserRepository _userRepository;

		public GetByIdUserQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<GetByIdUserResponseDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
		{
			await _userRepository.GetByIdAsync(request.Id);
			return new GetByIdUserResponseDto
			{
				Id = request.Id,
				Email = request.Email,
				Username = request.Username
			};
		}
	}
}
