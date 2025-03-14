using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.Actors;
using MovieApp.Application.Features.ActorFeature.Commands;
using MovieApp.Application.Features.ActorFeature.Queries;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ActorsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ActorsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllActor()
		{
			var queries = await _mediator.Send(new GetAllActorQuery());
			return Ok(queries);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdActor(int id)
		{
			GetByIdActorQuery query = new GetByIdActorQuery { Id = id };

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateActor([FromBody] CreateActorRequestDto model)
		{
			var command = _mapper.Map<CreateActorCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateActor([FromBody] UpdateActorRequestDto model)
		{
			var command = _mapper.Map<UpdateActorCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteActor(DeleteActorRequestDto model)
		{
			var command = _mapper.Map<DeleteActorCommand>(model);

			var response = await _mediator.Send(command);	
			return Ok(response);
		}
	}
}
