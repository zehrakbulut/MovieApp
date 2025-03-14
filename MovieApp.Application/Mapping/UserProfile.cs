using AutoMapper;
using MovieApp.Application.Dtos.Requests.Users;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Application.Features.UserFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<CreateUserRequestDto, User>();
			CreateMap<CreateUserRequestDto, CreateUserCommand>();
			CreateMap<CreateUserCommand, User>();
			CreateMap<User, CreateUserResponseDto>();

			CreateMap<UpdateUserRequestDto, UpdateUserCommand>();
			CreateMap<UpdateUserCommand, User>();
			CreateMap<User, UpdateUserResponseDto>();

			CreateMap<DeleteUserRequestDto, DeleteUserCommand>();

			CreateMap<GetByIdUserQuery, GetByIdUserResponseDto>();
			CreateMap<User, GetByIdUserResponseDto>();
		}
	}
}
