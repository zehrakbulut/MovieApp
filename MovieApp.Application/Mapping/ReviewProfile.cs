using AutoMapper;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Mapping
{
	public class ReviewProfile : Profile
	{
		public ReviewProfile()
		{
			CreateMap<Review, CreateReviewResponseDto>();

			CreateMap<Review, UpdateReviewResponseDto>();
			CreateMap<UpdateReviewCommand, Review>();

			CreateMap<Review, GetByIdReviewResponseDto>();
		}
	}
}
