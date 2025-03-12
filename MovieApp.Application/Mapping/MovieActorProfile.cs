using AutoMapper;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class MovieActorProfile : Profile
	{
		public MovieActorProfile()
		{
			CreateMap<MovieActor, CreateMovieActorResponseDto>();

			CreateMap<MovieActor, UpdateMovieActorResponseDto>();
			CreateMap<UpdateMovieActorCommand, MovieActor>();

			CreateMap<MovieActor, GetByIdMovieActorResponseDto>();
		}
	}
}
