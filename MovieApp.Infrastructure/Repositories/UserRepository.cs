using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DbMovieContext _context;

		public UserRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(User user)
		{
			await _context.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(User user)
		{
			_context.Remove(user);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task UpdateAsync(User user)
		{
			_context.Update(user);
			await _context.SaveChangesAsync();
		}
	}
}
