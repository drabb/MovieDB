using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MovieDB.Models;

namespace MovieDB.Tests.Models
{

    [TestClass]
    public class MovieTest
    {
        public MovieTest()
        {

        }
        
        [TestMethod]
        public void Movie_Should_Be_Invalid_When_Props_Incorrect()
        {
            Movie movie = new Movie()
            {
                title = "The Jerk",  // duplicate title
                year = 1894,  // out of range
                length = -5  // also out of range
            };

            bool isValid = movie.IsValid;

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Movie_Should_Be_Valid_When_Props_Correct()
        {
            Movie movie = new Movie()
            {
                title = "Test Title",
                year = DateTime.Now.Year,
                length = 100,
                genre_id = 3,
                rating_id = 1,
                director_id = 1,
                location_id = 1
            };

            bool isValid = movie.IsValid;

            Assert.IsTrue(isValid);
        }
    }
}
