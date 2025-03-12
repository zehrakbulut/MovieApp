using AutoMapper;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class GenreProfile : Profile
	{
		public GenreProfile()
		{
			CreateMap<Genre, CreateGenreResponseDto>();

			CreateMap<Genre, UpdateGenreResponseDto>();
			CreateMap<UpdateGenreCommand, Genre>();

			CreateMap<Genre, GetByIdGenreResponseDto>();
		}
	}
}
