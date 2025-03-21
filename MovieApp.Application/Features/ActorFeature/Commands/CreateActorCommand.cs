﻿using MediatR;
using MovieApp.Application.Dtos.Responses.Actors;

namespace MovieApp.Application.Features.ActorFeature.Commands
{
	public class CreateActorCommand : IRequest<CreateActorResponseDto>
	{
		public string Name { get; set; }
		public string Nationality { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
