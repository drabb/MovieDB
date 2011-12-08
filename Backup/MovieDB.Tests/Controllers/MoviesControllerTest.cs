﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MovieDB.Models;
using MovieDB.ViewModels;
using MovieDB.Controllers;
using MovieDB.Tests.TestRepos;

namespace MovieDB.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTest
    {
        List<Movie> CreateTestMovies()
        {
            List<Movie> movies = new List<Movie>();

            for (int i = 0; i < 101; i++)
            {
                Random r = new Random(i);

                Movie tmpMovie = new Movie()
                {
                    movie_id = i,
                    title = "Test Movie " + i.ToString(),
                    year = r.Next(1941, DateTime.Now.Year + 1),
                    length = r.Next(40, 200),
                    director_id = r.Next(4, 20),
                    genre_id = 3,
                    location_id = 1,
                    rating_id = 1
                };

                movies.Add(tmpMovie);
            }

            return movies;
        }

        MoviesController CreateMoviesController()
        {
            var repo = new FauxMovieRepository(CreateTestMovies());
            return new MoviesController(repo);
        }
        
        [TestMethod]
        public void DetailsAction_Should_Return_View_For_Existing_Movie()
        {   
            var controller = CreateMoviesController();

            var result = controller.Details(1) as ViewResult;

            Assert.IsNotNull(result, "Expected View");
        }

        [TestMethod]
        public void DetailsAction_Should_Return_NotFound_For_Bad_ID()
        {
            var controller = CreateMoviesController();

            var result = controller.Details(50102312) as ViewResult;

            Assert.AreEqual("NotFound", result.ViewName);
        }

        [TestMethod]
        public void EditAction_Should_Return_View_For_ValidMovie()
        {
            var controller = CreateMoviesController();

            var result = controller.Edit(1) as ViewResult;

            Assert.IsInstanceOfType(result.ViewData.Model, typeof(MovieFormViewModel));
        }
    }
}
