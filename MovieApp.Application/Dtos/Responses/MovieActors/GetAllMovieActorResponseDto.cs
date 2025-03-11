using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Application.Dtos.Responses.MovieActors
{
	public class GetAllMovieActorResponseDto
	{
		public List<GetByIdMovieActorResponseDto> MovieActors { get; set; }	
	}
}
