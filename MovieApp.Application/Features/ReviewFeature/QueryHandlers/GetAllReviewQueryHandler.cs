using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Reviews;
using MovieApp.Application.Features.ReviewFeature.Queries;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.ReviewFeature.QueryHandlers
{
	public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQuery, GetAllReviewResponseDto>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IMovieRepository _movieRepository;
		private readonly IMapper _mapper;

		public GetAllReviewQueryHandler(IReviewRepository reviewRepository, IMapper mapper, IMovieRepository movieRepository)
		{
			_reviewRepository = reviewRepository;
			_mapper = mapper;
			_movieRepository = movieRepository;
		}

		public async Task<GetAllReviewResponseDto> Handle(GetAllReviewQuery request, CancellationToken cancellationToken)
		{
			var reviews = await _reviewRepository.GetAllAsync() ?? new List<Review>();

			var movies = await _movieRepository.GetAllAsync();


			if (request.MostReviewed)
			{
				var topMovies = reviews
					.GroupBy(r => r.MovieId)
					.Select(g =>
				{
					var movie = movies.FirstOrDefault(m => m.Id == g.Key);
					return new
					{
						ReviewId = g.Key,
						MovieId = g.Key,
						Title = movie.Title,
						CommentCount = g.Count(),
						AverageRating = g.Average(r => r.Rating),
						UserId = g.Select(r => r.UserId).ToList()
					};
				})
				.OrderByDescending(g => g.CommentCount)
				.Take(request.Count)
				.ToList();

				var response = topMovies.Select(m => new GetByIdReviewResponseDto
				{
					Id = m.ReviewId,
					MovieId = m.MovieId,
					Comment = $"Yorum Sayısı: {m.CommentCount}",
					Rating = m.AverageRating,
					Title = m.Title,
				}).ToList();

				return new GetAllReviewResponseDto { Reviews = response };
			}
			else
			{
				var response = _mapper.Map<List<GetByIdReviewResponseDto>>(reviews);
				return new GetAllReviewResponseDto { Reviews = response };
			}
		}
	}
}
