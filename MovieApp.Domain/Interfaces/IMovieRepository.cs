using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IMovieRepository
	{
		Task<Movie> GetByIdAsync(int id);
		Task<IEnumerable<Movie>> GetAllAsync();
		Task AddAsync(Movie movie);
		Task UpdateAsync(Movie movie);
		Task DeleteAsync(Movie movie);
	}
}
