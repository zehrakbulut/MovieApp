using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class MovieActorRepository : IMovieActorRepository
	{
		private readonly DbMovieContext _context;

		public MovieActorRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(MovieActor movieActor)
		{
			await _context.AddAsync(movieActor);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(MovieActor movieActor)
		{
			_context.Remove(movieActor);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<MovieActor>> GetAllAsync()
		{
			return await _context.MovieActors.ToListAsync();
		}

		public async Task<MovieActor> GetByIdAsync(int id)
		{
			return await _context.MovieActors.FindAsync();
		}

		public async Task UpdateAsync(MovieActor movieActor)
		{
			_context.Update(movieActor);
			await _context.SaveChangesAsync();
		}
	}
}
