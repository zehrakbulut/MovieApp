﻿namespace MovieApp.Application.Dtos.Responses.Movies
{
	public class GetByIdMovieResponseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public decimal Rating { get; set; }
	}
}
