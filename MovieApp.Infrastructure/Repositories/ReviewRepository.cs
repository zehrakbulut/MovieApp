using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly DbMovieContext _context;

		public ReviewRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Review review)
		{
			await _context.AddAsync(review);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Review review)
		{
			_context.Remove(review);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Review>> GetAllAsync()
		{
			return await _context.Reviews.ToListAsync();
		}

		public async Task<Review> GetByIdAsync(int id)
		{
			return await _context.Reviews.FindAsync(id);
		}

		public async Task UpdateAsync(Review review)
		{
			_context.Update(review);
			await _context.SaveChangesAsync();
		}
	}
}
