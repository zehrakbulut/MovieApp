using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.Reviews;
using MovieApp.Application.Features.MovieFeature.Queries;
using MovieApp.Application.Features.ReviewFeature.Commands;
using MovieApp.Application.Features.ReviewFeature.Queries;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ReviewsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllReview()
		{
			var queries =await _mediator.Send(new GetAllReviewQuery());
			return Ok(queries);
		}

		[HttpGet("movies/{most-review}/count = 3")]
		public async Task<IActionResult> GetAllReview([FromQuery] bool mostReviewed = true, [FromQuery] int count = 3)
		{
			var query = new GetAllReviewQuery
			{
				MostReviewed = mostReviewed,
				Count = count
			};

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdReview(int id)
		{
			GetByIdReviewQuery query = new GetByIdReviewQuery { Id = id };

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpGet("users/{userId}/reviews")]
		public async Task<IActionResult> GetUserReview(int userId)
		{
			GetUserReviewQuery query = new GetUserReviewQuery { UserId = userId };

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequestDto model)
		{
			var command = _mapper.Map<CreateReviewCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewRequestDto model)
		{
			var command = _mapper.Map<UpdateReviewCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteReview(DeleteReviewRequestDto model)
		{
			var command = _mapper.Map<DeleteReviewCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
