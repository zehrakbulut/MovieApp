﻿namespace MovieApp.Domain.Models.Tables
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Movie> Movies { get; set; } = new List<Movie>();
	}
}
