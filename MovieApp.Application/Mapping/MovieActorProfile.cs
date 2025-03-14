using AutoMapper;
using MovieApp.Application.Dtos.Requests.MovieActors;
using MovieApp.Application.Dtos.Responses.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Application.Features.MovieActorFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class MovieActorProfile : Profile
	{
		public MovieActorProfile()
		{
			CreateMap<CreateMovieActorRequestDto, MovieActor>();
			CreateMap<CreateMovieActorRequestDto, CreateMovieActorCommand>();
			CreateMap<CreateMovieActorCommand, MovieActor>();
			CreateMap<MovieActor, CreateMovieActorResponseDto>();

			CreateMap<UpdateMovieActorRequestDto, UpdateMovieActorCommand>();
			CreateMap<UpdateMovieActorCommand, MovieActor>();
			CreateMap<MovieActor, UpdateMovieActorResponseDto>();

			CreateMap<DeleteMovieActorRequestDto, DeleteMovieActorCommand>();

			CreateMap<GetByIdMovieActorQuery, GetByIdMovieActorResponseDto>();
			CreateMap<MovieActor, GetByIdMovieActorResponseDto>();
		}
	}
}
