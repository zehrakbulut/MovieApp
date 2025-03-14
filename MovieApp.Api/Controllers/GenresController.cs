using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.Genres;
using MovieApp.Application.Features.GenreFeature.Commands;
using MovieApp.Application.Features.GenreFeature.Queries;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenresController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public GenresController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllGenre()
		{
			var query = await _mediator.Send(new GetAllGenreQuery());
			return Ok(query);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdGenre(int id)
		{
			GetByIdGenreQuery query = new GetByIdGenreQuery { Id = id};

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequestDto model)
		{
			var command = _mapper.Map<CreateGenreCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequestDto model)
		{
			var command = _mapper.Map<UpdateGenreCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteGenre(DeleteGenreRequestDto model)
		{
			var command = _mapper.Map<DeleteGenreCommand>(model);

			var response = await _mediator.Send(command);	
			return Ok(response);
		}
	}
}
