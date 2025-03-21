﻿using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IMovieActorRepository
	{
		Task<MovieActor> GetByIdAsync(int movieId, int actorId);
		Task<IEnumerable<MovieActor>> GetAllAsync();
		Task AddAsync(MovieActor movieActor);
		Task UpdateAsync(MovieActor movieActor);
		Task DeleteAsync(MovieActor movieActor);
	}
}
