﻿using MovieApp.Domain.Models.Tables;

namespace MovieApp.Domain.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetByIdAsync(int id);
		Task<IEnumerable<User>> GetAllAsync();
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task DeleteAsync(User user);
	}
}
