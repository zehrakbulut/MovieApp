using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.Movies;
using MovieApp.Application.Features.MovieFeature.Commands;
using MovieApp.Application.Features.MovieFeature.Queries;
using System.Net.Mime;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public MoviesController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllMovie()
		{
			var queries = await _mediator.Send(new GetAllMovieQuery());
			return Ok(queries);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdMovie(int id)
		{
			GetByIdMovieQuery query = new GetByIdMovieQuery { Id = id };

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		

		[HttpGet("top-movie")]
		public async Task<IActionResult> GetTopMovie(int count)
		{
			var query = new GetTopMovieQuery { Count = count };

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequestDto model)
		{
			var command = _mapper.Map<CreateMovieCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequestDto model)
		{
			var command = _mapper.Map<UpdateMovieCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteMovie(DeleteMovieRequestDto model)
		{
			var command = _mapper.Map<DeleteMovieCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
