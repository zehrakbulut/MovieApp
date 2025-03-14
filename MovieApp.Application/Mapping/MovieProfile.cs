using AutoMapper;
using MovieApp.Application.Dtos.Requests.Movies;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class MovieProfile : Profile
	{
		public MovieProfile()
		{
			CreateMap<CreateMovieRequestDto, Movie>();
			CreateMap<CreateMovieRequestDto, CreateMovieCommand>();
			CreateMap<CreateMovieCommand, Movie>();
			CreateMap<Movie, CreateMovieResponseDto>();

			CreateMap<UpdateMovieRequestDto, UpdateMovieCommand>();
			CreateMap<UpdateMovieCommand, Movie>();
			CreateMap<Movie, UpdateMovieResponseDto>();

			CreateMap<DeleteMovieRequestDto, DeleteMovieCommand>();

			CreateMap<GetByIdMovieQuery, GetByIdMovieResponseDto>();
			CreateMap<Movie, GetByIdMovieResponseDto>();
		}
	}
}
