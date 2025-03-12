using MediatR;
using MovieApp.Application.Dtos.Responses.Directors;

namespace MovieApp.Application.Features.DirectorFeature.Commands
{
	public class DeleteDirectorCommand : IRequest<DeleteDirectorResponseDto>
	{
		public int Id { get; set; }
	}
}
