using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.QueryHandlers
{
	public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserResponseDto>
	{
		private readonly IUserRepository _userRepository;

		public GetAllUserQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<GetAllUserResponseDto> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetAllAsync();
			var userResponse = users.Select(user => new GetByIdUserResponseDto
			{
				Id = user.Id,
				Username = user.Username,
				Email = user.Email
			}).ToList();

			return new GetAllUserResponseDto { Users = userResponse };
		}
	}
}
