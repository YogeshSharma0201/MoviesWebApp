using Moq;
using Movies.Models;
using Movies.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MovieTest
{
    public class Tests
    {
        private Mock<IMovieDataContextService> _movieDataContextService;

        [SetUp]
        public void Setup()
        {
            // Test Data
            List<MovieEntity> Movies = new List<MovieEntity>
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

            _movieDataContextService = new Mock<IMovieDataContextService>();

            _movieDataContextService.Setup(v => v.FindAll()).Returns(Movies);

            _movieDataContextService.Setup(v =>
                v.FindWithPagination(It.IsAny<int>(), It.IsAny<int>())).Returns(Movies.Skip(5).ToList());
        }

        [TestCase(null, null, 10)]
        [TestCase(2, 5, 5)]
        public void TestMoviesFindByPage(int? pageNumber, int? pageSize, int expectedOutput)
        {
            var movies = new MovieService(_movieDataContextService.Object);

            Assert.AreEqual(movies.FindAll(pageNumber, pageSize).Count, expectedOutput);
        }
    }
}