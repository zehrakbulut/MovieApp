using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Commands;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.CommandHandlers
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;
		public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdAsync(request.Id);
			if (user == null) return new UpdateUserResponseDto { Success = false };

			_mapper.Map(request, user);
			await _userRepository.UpdateAsync(user);
			return new UpdateUserResponseDto
			{
				Success = true,
				Username = user.Username,
				Email = user.Email
			};
		}
	}
}
