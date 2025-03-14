using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.Directors;
using MovieApp.Application.Features.DirectorFeature.Commands;
using MovieApp.Application.Features.DirectorFeature.Queries;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectorsController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public DirectorsController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDirector()
		{
			var directors = await _mediator.Send(new GetAllDirectorQuery());
			return Ok(directors);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdDirector(int id)
		{
			GetByIdDirectorQuery query = new GetByIdDirectorQuery{ Id = id};

			var director = await _mediator.Send(query);
			return Ok(director);
		}

		[HttpPost]
		public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorRequestDto model)
		{
			var command = _mapper.Map<CreateDirectorCommand>(model);

			var director = await _mediator.Send(command);
			return Ok(director);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateDirector(UpdateDirectorRequestDto model)
		{
			var command = _mapper.Map<UpdateDirectorCommand>(model);

			var director = await _mediator.Send(command);
			return Ok(director);	
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteDirector(DeleteDirectorRequestDto model)
		{
			var command = _mapper.Map<DeleteDirectorCommand>(model);

			var director = await _mediator.Send(command);
			return Ok(director);
		}
	}
}
