﻿namespace MovieApp.Application.Dtos.Responses.Reviews
{
	public class GetByIdReviewResponseDto
	{
		public int Id { get; set; }
		public int MovieId { get; set; }
		public int UserId { get; set; }
		public string Comment { get; set; }
	}
}
