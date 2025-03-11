using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IMovieActorRepository
	{
		Task<MovieActor> GetByIdAsync(int id);
		Task<IEnumerable<MovieActor>> GetAllAsync();
		Task AddAsync(MovieActor movieActor);
		Task UpdateAsync(MovieActor movieActor);
		Task DeleteAsync(MovieActor movieActor);
	}
}
