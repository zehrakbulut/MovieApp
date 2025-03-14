using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Application.Features.UserFeature.CommandHandlers
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var user = _mapper.Map<User>(request);
			await _userRepository.AddAsync(user);
			return new CreateUserResponseDto
			{
				Success = true,
				Username = user.Username,
				Email = user.Email
			};
		}
	}
}