using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Dtos.Requests.Users;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Application.Features.UserFeature.Queries;

namespace MovieApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public UsersController(IMediator mediator, IMapper mapper)
		{
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUser()
		{
			var queries = await _mediator.Send(new GetAllUserQuery());
			return Ok(queries);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdUser(int id)
		{
			GetByIdUserQuery query = new GetByIdUserQuery { Id = id };

			var response = await _mediator.Send(query);
			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto model)
		{
			var command = _mapper.Map<CreateUserCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(UpdateUserRequestDto model)
		{
			var command = _mapper.Map<UpdateUserCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteUser(DeleteUserRequestDto model)
		{
			var command = _mapper.Map<DeleteUserCommand>(model);

			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
