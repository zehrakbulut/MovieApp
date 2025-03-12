using MediatR;
using MovieApp.Application.Dtos.Responses.Users;

namespace MovieApp.Application.Features.UserFeature.Commands
{
	public class DeleteUserCommand : IRequest<DeleteUserResponseDto>
	{
		public int Id { get; set; }
	}
}
