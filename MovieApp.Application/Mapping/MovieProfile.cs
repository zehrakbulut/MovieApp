using AutoMapper;
using MovieApp.Application.Dtos.Responses.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class MovieProfile : Profile
	{
		public MovieProfile()
		{
			CreateMap<Movie, CreateMovieResponseDto>();

			CreateMap<Movie, UpdateMovieResponseDto>();
			CreateMap<UpdateMovieCommand, Movie>();

			CreateMap<Movie, GetByIdMovieResponseDto>();
		}
	}
}
