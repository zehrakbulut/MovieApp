using MediatR;
using MovieApp.Application.Dtos.Responses.Users;

namespace MovieApp.Application.Features.UserFeature.Commands
{
	public class UpdateUserCommand : IRequest<UpdateUserResponseDto>
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
