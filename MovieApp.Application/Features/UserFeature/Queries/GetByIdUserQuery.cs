using MediatR;
using MovieApp.Application.Dtos.Responses.Users;

namespace MovieApp.Application.Features.UserFeature.Queries
{
	public class GetByIdUserQuery : IRequest<GetByIdUserResponseDto>
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
	}
}
