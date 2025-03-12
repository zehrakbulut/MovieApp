using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;

namespace MovieApp.Application.Features.ActorFeature.Queries
{
	public class GetByIdActorQuery : IRequest<GetByIdActorResponseDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
	}
}
