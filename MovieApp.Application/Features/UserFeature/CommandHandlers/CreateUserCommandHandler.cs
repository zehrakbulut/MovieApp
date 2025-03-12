using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.UserFeature.CommandHandlers
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDto>
	{
		private readonly IUserRepository _userRepository;

		public CreateUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = new User
			{
				Username = request.Username,
				Email = request.Email,
				Password = request.Password
			};

			await _userRepository.AddAsync(user);
			return new CreateUserResponseDto
			{
				Success = true,
				Username = request.Username,
				Email = request.Email,
			};
		}
	}
}
