using MediatR;
using MovieApp.Application.Dtos.Responses.Users;

namespace MovieApp.Application.Features.UserFeature.Queries
{
	public class GetAllUserQuery : IRequest<GetAllUserResponseDto>
	{
	}
}
