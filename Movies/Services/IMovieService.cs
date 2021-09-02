using Movies.Models;
using System.Collections.Generic;

namespace Movies.Services
{
    public interface IMovieService
    {
		List<MovieEntity> FindAll(int? pageNumber, int? pageSize);

		MovieEntity FindOne(int id);

		MovieEntity Create(CreateMovieEntity createMovieEntity);
	}
}