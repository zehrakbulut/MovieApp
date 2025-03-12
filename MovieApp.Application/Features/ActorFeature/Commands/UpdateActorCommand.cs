using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;

namespace MovieApp.Application.Features.ActorFeature.Commands
{
	public class UpdateActorCommand : IRequest<UpdateActorResponseDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
