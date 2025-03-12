using AutoMapper;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, CreateUserResponseDto>();

			CreateMap<User, UpdateUserResponseDto>();
			CreateMap<UpdateUserCommand, User>();

			CreateMap<User, GetByIdUserResponseDto>();
		}
	}
}
