using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.CommandHandlers
{
	public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponseDto>
	{
		private readonly IUserRepository _userRepository;

		public DeleteUserCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<DeleteUserResponseDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			if (user == null) return new DeleteUserResponseDto { Success = false };

			await _userRepository.DeleteAsync(user);
			return new DeleteUserResponseDto { Success = true };
		}
	}
}
