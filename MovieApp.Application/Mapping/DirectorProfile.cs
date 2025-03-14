using AutoMapper;
using MovieApp.Application.Dtos.Requests.Directors;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Application.Features.DirectorFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class DirectorProfile : Profile
	{
		public DirectorProfile()
		{
			CreateMap<Director, CreateDirectorResponseDto>();
			CreateMap<CreateDirectorRequestDto, Director>();
			CreateMap<CreateDirectorRequestDto, CreateDirectorCommand>();
			CreateMap<CreateDirectorCommand, Director>();

			CreateMap<Director, UpdateDirectorResponseDto>();
			CreateMap<UpdateDirectorCommand, Director>();
			CreateMap<UpdateDirectorRequestDto, UpdateDirectorCommand>();

			CreateMap<DeleteDirectorRequestDto, DeleteDirectorCommand>();

			CreateMap<Director, GetByIdDirectorResponseDto>();
			CreateMap<GetByIdDirectorQuery, GetByIdDirectorResponseDto>();
		}
	}
}
