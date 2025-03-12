using AutoMapper;
using MediatR;
using MovieApp.Application.Dtos.Responses.Users;
using MovieApp.Application.Features.UserFeature.Queries;
using MovieApp.Domain.Interfaces;

namespace MovieApp.Application.Features.UserFeature.QueryHandlers
{
	public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponseDto>
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<GetByIdUserResponseDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
		{
			await _userRepository.GetByIdAsync(request.Id);
			return _mapper.Map<GetByIdUserResponseDto>(request);
		}
	}
}
