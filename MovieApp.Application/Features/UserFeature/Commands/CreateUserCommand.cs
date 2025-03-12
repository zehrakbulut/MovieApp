using MediatR;
using MovieApp.Application.Dtos.Responses.Users;

namespace MovieApp.Application.Features.UserFeature.Commands
{
	public class CreateUserCommand : IRequest<CreateUserResponseDto>
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
