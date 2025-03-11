using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Interfaces;
using MovieApp.Domain.Models.Tables;
using MovieApp.Infrastructure.Context;

namespace MovieApp.Infrastructure.Repositories
{
	public class ActorRepository : IActorRepository
	{
		private readonly DbMovieContext _context;

		public ActorRepository(DbMovieContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Actor actor)
		{
			await _context.AddAsync(actor);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Actor actor)
		{
			_context.Actors.Remove(actor);
			await _context.SaveChangesAsync();
		}

		public  async Task<IEnumerable<Actor>> GetAllAsync()
		{
			return await _context.Actors.ToListAsync();
		}

		public async Task<Actor> GetByIdAsync(int id)
		{
			return await _context.Actors.FindAsync(id);
		}

		public async Task UpdateAsync(Actor actor)
		{
			_context.Actors.Update(actor);
			await _context.SaveChangesAsync();
		}
	}
}
