using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.QueryHandlers
{
	public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserResponseDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<GetAllUserResponseDto> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetAllAsync();
			var userResponse = _mapper.Map<IEnumerable<GetByIdUserResponseDto>>(users).ToList();

			return new GetAllUserResponseDto { Users = userResponse };
		}
	}
}
