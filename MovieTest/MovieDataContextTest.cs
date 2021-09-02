using Movies.Models;
using Movies.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTest
{
    public class MovieDataContextTests
    {
        [TestCase(1, 10, 10)]
        [TestCase(2, 5, 5)]
        public void TestMoviesFindByPage(int pageNumber, int pageSize, int expectedOutput)
        {
            var movies = new MovieDataContextService();

            Assert.AreEqual(movies.FindWithPagination(pageNumber, pageSize).Count, expectedOutput);
        }

        [Test]
        public void TestMoviesCreate()
        {
            var movie = new CreateMovieEntity()
            {
                Title = "Test",
                Director = "Director"
            };

            var movies = new MovieDataContextService();

            Assert.AreEqual(movies.FindAll().Count, 10);

            movies.Create(movie);

            Assert.AreEqual(movies.FindAll().Count, 11);
        }
    }
}
