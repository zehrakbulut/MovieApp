using AutoMapper;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class ActorProfile : Profile
	{
		public ActorProfile()
		{
			CreateMap<Actor, CreateActorResponseDto>();

			CreateMap<Actor, UpdateActorResponseDto>();
			CreateMap<UpdateActorCommand, Actor>();

			CreateMap<Actor, GetByIdActorResponseDto>();
		}
	}
}
