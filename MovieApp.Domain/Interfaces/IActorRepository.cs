using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IActorRepository
	{
		Task<Actor> GetByIdAsync(int id);
		Task<IEnumerable<Actor>> GetAllAsync();
		Task AddAsync(Actor actor);
		Task UpdateAsync(Actor actor);
		Task DeleteAsync(Actor actor);
	}
}
