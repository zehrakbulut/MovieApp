using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IReviewRepository
	{
		Task<Review> GetByIdAsync(int id);
		Task<IEnumerable<Review>> GetAllAsync();
		Task AddAsync(Review review);
		Task UpdateAsync(Review review);
		Task DeleteAsync(Review review);
	}
}
