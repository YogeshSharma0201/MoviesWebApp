using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public class MovieService : IMovieService
	{
		private readonly IMovieDataContextService _movieDataContextService;

		public MovieService(IMovieDataContextService movieDataContextService)
        {
			_movieDataContextService = movieDataContextService;
		}

		public List<MovieEntity> FindAll(int? pageNumber, int? pageSize)
		{
			// default pagesize of 10
			pageSize ??= 10;

			// if no pagenumber passed return all movies
			if(pageNumber == null)
            {
				return _movieDataContextService.FindAll();

			}
			else
            {
				return _movieDataContextService.FindWithPagination(pageNumber.Value, pageSize.Value);
			}
		}

		public MovieEntity FindOne(int id)
		{
			return _movieDataContextService.FindOne(id);
		}

		public MovieEntity Create(CreateMovieEntity createMovieEntity)
		{
			return _movieDataContextService.Create(createMovieEntity);
		}
	}
}
