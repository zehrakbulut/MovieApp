using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.MovieActors;
using MovieApp.Application.Features.MovieActorFeature.Commands;
using MovieApp.Application.Features.MovieActorFeature.Queries;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieActorsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public MovieActorsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllMovieActor()
		{
			var queries = await _mediator.Send(new GetAllMovieActorQuery());
			return Ok(queries);
		}

		[HttpGet("{movieId}/{actorId}")]
		public async Task<IActionResult> GetByIdMovieActor(int movieId, int actorId)
		{
			var query = new GetByIdMovieActorQuery { MovieId = movieId, ActorId = actorId };

			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("{movieId}/cast")]
		public async Task<IActionResult> GetMovieCast(string cast)
		{
			var query = new GetAllMovieActorQuery { Cast = cast };

			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateMovieActor([FromBody] CreateMovieActorRequestDto model)
		{
			var command = _mapper.Map<CreateMovieActorCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("{movieId}/{actorId}")]
		public async Task<IActionResult> UpdateMovieActor(int movieId, int actorId, UpdateMovieActorRequestDto model)
		{
			var command = _mapper.Map<UpdateMovieActorCommand>(model);
			command.MovieId = movieId; 
			command.ActorId = actorId;

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteMovieActor(DeleteMovieActorRequestDto model)
		{
			var command = _mapper.Map<DeleteMovieActorCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
