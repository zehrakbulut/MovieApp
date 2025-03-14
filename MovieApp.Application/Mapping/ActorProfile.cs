using AutoMapper;
using MovieApp.Application.Dtos.Requests.Actors;
using MovieApp.Application.Dtos.Responses.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Application.Features.ActorFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class ActorProfile : Profile
	{
		public ActorProfile()
		{
			CreateMap<CreateActorRequestDto, Actor>();
			CreateMap<CreateActorRequestDto, CreateActorCommand>();
			CreateMap<CreateActorCommand, Actor>();
			CreateMap<Actor, CreateActorResponseDto>();

			CreateMap<GetByIdActorQuery, GetByIdActorResponseDto>();
			CreateMap<Actor, GetByIdActorResponseDto>();

			CreateMap<DeleteActorRequestDto, DeleteActorCommand>();

			CreateMap<UpdateActorRequestDto, UpdateActorCommand>();
			CreateMap<UpdateActorCommand, Actor>();
			CreateMap<Actor, UpdateActorResponseDto>();
		}
	}
}
