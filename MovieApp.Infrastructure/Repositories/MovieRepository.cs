using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class MovieRepository : IMovieRepository
	{
		private readonly DbMovieContext _context;

		public MovieRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Movie movie)
		{
			await _context.AddAsync(movie);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Movie movie)
		{
			_context.Remove(movie);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Movie>> GetAllAsync()
		{
			return await _context.Movies.ToListAsync();
		}

		public async Task<Movie> GetByIdAsync(int id)
		{
			return await _context.Movies.FindAsync(id);
		}

		public async Task<List<Movie>> GetTopMovieAsync(int count)
		{
			return await _context.Movies
				.OrderByDescending(m => m.Rating)
				.ThenBy(m => m.Title)
				.Take(count)
				.ToListAsync();
		}

		public async Task UpdateAsync(Movie movie)
		{
			_context.Update(movie);
			await _context.SaveChangesAsync();
		}
	}
}
