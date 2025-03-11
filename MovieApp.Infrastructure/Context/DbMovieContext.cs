using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Models.Tables;

namespace MovieApp.Infrastructure.Context
{
	public class DbMovieContext : DbContext
	{
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Director> Directors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<MovieActor> MovieActors { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<User> Users { get; set; }

		public DbMovieContext(DbContextOptions<DbMovieContext> options) : base(options) { }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MovieActor>()
				.HasKey(ma => new { ma.MovieId, ma.ActorId });

			modelBuilder.Entity<MovieActor>()
				.HasOne(ma => ma.Movie)
				.WithMany(m => m.MovieActors)
				.HasForeignKey(ma => ma.MovieId);

			modelBuilder.Entity<MovieActor>()
				.HasOne(ma => ma.Actor)
				.WithMany(m => m.MovieActors)
				.HasForeignKey(ma => ma.ActorId);

			//review-movie 
			// şu satırdan sonrasına gerek yok aslında otomatik oluyor
			modelBuilder.Entity<Review>()
				.HasOne(r => r.Movie)
				.WithMany(m => m.Reviews)
				.HasForeignKey(r => r.MovieId);

			//user-review
			modelBuilder.Entity<Review>()
				.HasOne(u => u.User)
				.WithMany(r => r.Reviews)
				.HasForeignKey(u => u.UserId);

			//movie-director
			modelBuilder.Entity<Movie>()
				.HasOne(m => m.Director)
				.WithMany(d => d.Movies)
				.HasForeignKey(m => m.DirectorId);

			//movie-genre
			modelBuilder.Entity<Movie>()
				.HasOne(m => m.Genre)
				.WithMany(g => g.Movies)
				.HasForeignKey(m => m.GenreId);
		}
	}
}
