using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MovieDataContextService : IMovieDataContextService
	{
        private List<MovieEntity> Movies = new List<MovieEntity>
		{
			new MovieEntity { Id = 1, Title = "Toy Story 1", Director = "John Lasseter" },
			new MovieEntity { Id = 2, Title = "Toy Story 4", Director = "Josh Cooley" },
			new MovieEntity { Id = 3, Title = "Arrival", Director = "Denis Villeneuve" },
			new MovieEntity { Id = 4, Title = "Interstellar", Director = "Christopher Nolan" },
			new MovieEntity { Id = 5, Title = "The Martian", Director = "Ridley Scott" },
			new MovieEntity { Id = 6, Title = "Avatar", Director = "James Cameron" },
			new MovieEntity { Id = 7, Title = "Prometheus", Director = "Ridley Scott" },
			new MovieEntity { Id = 8, Title = "Sunshine", Director = "Danny Boyle" },
			new MovieEntity { Id = 9, Title = "Serenity", Director = "Joss Whedon" },
			new MovieEntity { Id = 10, Title = "WALL-E", Director = "Andrew Stanton" },
		};

		public List<MovieEntity> FindAll()
        {
			return Movies;
		}

		public List<MovieEntity> FindWithPagination(int pageNumber, int pageSize)
        {
			var moviesToSkip = Math.Max((pageNumber - 1) * pageSize, 0);
			var moviesToTake = pageSize;

			return FindAll().Skip(moviesToSkip).Take(moviesToTake).ToList();
		}

		public MovieEntity FindOne(int id)
        {
			var movie = Movies.FirstOrDefault(x => x.Id == id);

			return movie;
		}

		public MovieEntity Create(CreateMovieEntity createMovieEntity)
        {
			// check if already exists
			if(Movies.Any(x => x.Title == createMovieEntity.Title))
            {
				throw new Exception("Movie with same name already exists!!");
            }

			// Find correct Id for the movie
			var maxId = Movies.Max(x => x.Id) + 1;

			var movie = new MovieEntity(createMovieEntity, maxId);

			Movies.Add(movie);

			return movie;
		}
    }
}
