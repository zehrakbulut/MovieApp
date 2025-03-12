using AutoMapper;
using MovieApp.Application.Dtos.Responses.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class DirectorProfile : Profile
	{
		public DirectorProfile()
		{
			CreateMap<Director, CreateDirectorResponseDto>();

			CreateMap<Director, UpdateDirectorResponseDto>();
			CreateMap<UpdateDirectorCommand, Director>();

			CreateMap<Director, GetByIdDirectorResponseDto>();
		}
	}
}
