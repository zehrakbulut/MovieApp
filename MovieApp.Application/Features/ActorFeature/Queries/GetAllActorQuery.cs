using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;

namespace MovieApp.Application.Features.ActorFeature.Queries
{
	public class GetAllActorQuery : IRequest<GetAllActorReponseDto>
	{
	}
}
