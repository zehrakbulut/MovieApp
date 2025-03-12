using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.CommandHandlers
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
	{
		private readonly IUserRepository _userRepository;

		public UpdateUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			if (user == null) return new UpdateUserResponseDto { Success = false };

			await _userRepository.UpdateAsync(user);
			return new UpdateUserResponseDto
			{
				Success = true,
				Email = request.Email,
				Username = request.Username
			};
		}
	}
}
