using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IDirectorRepository
	{
		Task<Director> GetByIdAsync(int id);
		Task<IEnumerable<Director>> GetAllAsync();
		Task AddAsync(Director director);
		Task UpdateAsync(Director director);
		Task DeleteAsync(Director director);
	}
}
