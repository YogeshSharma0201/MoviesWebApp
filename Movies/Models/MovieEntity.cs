using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
	public class MovieEntity
	{
		public MovieEntity() {}

		public MovieEntity(CreateMovieEntity createMovieEntity, int id)
        {
			Id = id;
			Title = createMovieEntity.Title;
			Director = createMovieEntity.Director;
        }
		public int Id { get; set; }
		public string Title { get; set; }
		public string Director { get; set; }
	}
}
