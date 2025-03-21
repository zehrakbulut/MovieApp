using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Application.Features.ActorFeature.CommandHandlers;
using MovieApp.Application.Features.DirectorFeature.CommandHandlers;
using MovieApp.Application.Mapping;
using MovieApp.Domain.Interfaces;
using MovieApp.Infrastructure.Context;
using MovieApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ActorProfile), typeof(DirectorProfile), typeof(GenreProfile), typeof(MovieProfile),typeof(MovieActorProfile), typeof(ReviewProfile), typeof(UserProfile)); 

builder.Services.AddMediatR(typeof(CreateActorCommandHandler).Assembly, typeof(CreateDirectorCommandHandler).Assembly); 


builder.Services.AddDbContext<DbMovieContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieActorRepository, MovieActorRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
