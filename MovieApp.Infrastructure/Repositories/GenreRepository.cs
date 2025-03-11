using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class GenreRepository : IGenreRepository
	{
		private readonly DbMovieContext _context;

		public GenreRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Genre genre)
		{
			await _context.AddAsync(genre);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Genre genre)
		{
			_context.Remove(genre);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Genre>> GetAllAsync()
		{
			return await _context.Genres.ToListAsync();
		}

		public async Task<Genre> GetByIdAsync(int id)
		{
			return await _context.Genres.FindAsync(id);
		}

		public async Task UpdateAsync(Genre genre)
		{
			_context.Update(genre);
			await _context.SaveChangesAsync();
		}
	}
}
