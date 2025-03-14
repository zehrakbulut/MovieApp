using AutoMapper;
using MovieApp.Application.Dtos.Requests.Genres;
using MovieApp.Application.Dtos.Responses.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Application.Features.GenreFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class GenreProfile : Profile
	{
		public GenreProfile()
		{
			CreateMap<Genre, CreateGenreResponseDto>();
			CreateMap<CreateGenreRequestDto, Genre>();
			CreateMap<CreateGenreRequestDto, CreateGenreCommand>();
			CreateMap<CreateGenreCommand, Genre>();

			CreateMap<UpdateGenreRequestDto, UpdateGenreCommand>();
			CreateMap<UpdateGenreCommand, Genre>();
			CreateMap<Genre, UpdateGenreResponseDto>();

			CreateMap<DeleteGenreRequestDto, DeleteGenreCommand>();

			CreateMap<Genre, GetByIdGenreResponseDto>();
			CreateMap<GetByIdGenreQuery, GetByIdGenreResponseDto>();
		}
	}
}
