using Movies.Models;
using System.Collections.Generic;

namespace Movies.Services
{
    public interface IMovieDataContextService
    {
		List<MovieEntity> FindAll();

		List<MovieEntity> FindWithPagination(int pageNumber, int pageSize);

		MovieEntity FindOne(int id);

		MovieEntity Create(CreateMovieEntity createMovieEntity);
	}
}