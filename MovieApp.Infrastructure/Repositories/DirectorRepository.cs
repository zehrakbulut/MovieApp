using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class DirectorRepository : IDirectorRepository
	{
		private readonly DbMovieContext _context;

		public DirectorRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Director director)
		{
			await _context.AddAsync(director);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Director director)
		{
			_context.Remove(director);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Director>> GetAllAsync()
		{
			return await _context.Directors.ToListAsync();
		}

		public async Task<Director> GetByIdAsync(int id)
		{
			return await _context.Directors.FindAsync(id);
		}

		public async Task UpdateAsync(Director director)
		{
			_context.Update(director);
			await _context.SaveChangesAsync();
		}
	}
}
