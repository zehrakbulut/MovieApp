using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IGenreRepository
	{
		Task<Genre> GetByIdAsync(int id);
		Task<IEnumerable<Genre>> GetAllAsync();
		Task AddAsync(Genre genre);
		Task UpdateAsync(Genre genre);
		Task DeleteAsync(Genre genre);
	}
}
