using AutoMapper;
using MovieApp.Application.Dtos.Requests.Reviews;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class ReviewProfile : Profile
	{
		public ReviewProfile()
		{
			CreateMap<CreateReviewRequestDto, Review>();
			CreateMap<CreateReviewRequestDto, CreateReviewCommand>();
			CreateMap<CreateReviewCommand, Review>();
			CreateMap<Review, CreateReviewResponseDto>();

			CreateMap<UpdateReviewRequestDto, UpdateReviewCommand>();
			CreateMap<UpdateReviewCommand, Review>();
			CreateMap<Review, UpdateReviewResponseDto>();

			CreateMap<DeleteReviewRequestDto, DeleteReviewCommand>();

			CreateMap<GetByIdReviewQuery, GetByIdReviewResponseDto>();
			CreateMap<Review, GetByIdReviewResponseDto>();

			CreateMap<Review, GetUserReviewResponseDto>()
				.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
				.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Movie.Title))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Movie.Description));
		}
	}
}
