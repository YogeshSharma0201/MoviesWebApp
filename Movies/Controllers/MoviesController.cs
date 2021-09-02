using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Models;
using Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Movies.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MoviesController : ControllerBase
	{
		private readonly IMovieService _movieService;

		public MoviesController(IMovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		[Route("/")]
		public IActionResult Get(int? pageNumber, int? pageSize)
		{
			return Ok(_movieService.FindAll(pageNumber, pageSize));
		}

		[HttpGet]
		[Route("/{id}")]
		public IActionResult Get(int id)
		{
			var movie = _movieService.FindOne(id);

			if (movie == null) return new StatusCodeResult(404);
			return Ok(movie);
		}

		[HttpPost]
		[Route("/")]
		public IActionResult Post(CreateMovieEntity createMovieEntity)
		{
			var createdMovie = _movieService.Create(createMovieEntity);

			return Ok(createdMovie);
		}
	}
}
