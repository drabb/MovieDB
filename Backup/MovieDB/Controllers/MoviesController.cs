using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using MovieDB.Helpers;
using MovieDB.Models;
using MovieDB.ViewModels;

namespace MovieDB.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository movieRepo;
        private const int _pageSize = 20;

        public MoviesController() : this(new MovieRepository()) { }
        public MoviesController(IMovieRepository repository) { movieRepo = repository; }

        // GET: /Movies/
        public ActionResult Index(int? page)
        {   
            var movies = movieRepo.GetAllMovies().OrderBy(m => m.title);
            var pagedMovies = new PaginatedList<Movie>(movies, page ?? 0, _pageSize);

            ViewData["FilterData"] = new MovieFormViewModel();

            ViewData["YearMin"] = movies.OrderBy(m => m.year).First<Movie>().year;
            ViewData["YearMax"] = movies.OrderByDescending(m => m.year).First<Movie>().year;
            ViewData["LengthMin"] = movies.OrderBy(m => m.length).First<Movie>().length;
            ViewData["LengthMax"] = movies.OrderByDescending(m => m.length).First<Movie>().length;

            return View(pagedMovies);
        }

        // GET: /Movies/Details/x
        public ActionResult Details(int id)
        {
            Movie movie = movieRepo.GetMovie(id);
            return (movie == null) ? View("NotFound") : View(movie);
        }
        
        // GET: /Movies/Edit/x
        public ActionResult Edit(int id)
        {
            Movie movie = movieRepo.GetMovie(id);
            return View(new MovieFormViewModel(movie));
        }

        // POST: /Movies/Edit/x
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Movie movie = movieRepo.GetMovie(id);
            MovieFormViewModel viewMovie = new MovieFormViewModel(movie);

            try
            {
                UpdateModel(viewMovie);
                movieRepo.Save();

                return RedirectToAction("Details", new { id = movie.movie_id });
            }
            catch
            {
                ModelState.AddRuleViolations(movie.GetRuleViolations());
                return View(new MovieFormViewModel(movie));
            }   
        }

        // GET: /Movies/Create/
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(new MovieFormViewModel(movie));
        }

        // POST: /Movies/Create/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(movie);
                    movieRepo.Add(movie);

                    movieRepo.Save();

                    return RedirectToAction("Details", new { id = movie.movie_id });
                }
                catch
                {
                    ModelState.AddRuleViolations(movie.GetRuleViolations());
                }
            }

            return View(new MovieFormViewModel(movie));
        }

        // GET: /Movies/Delete/x
        public ActionResult Delete(int id)
        {
            Movie movie = movieRepo.GetMovie(id);
            return (movie == null) ? View("NotFound") : View(movie);
        }

        // POST: /Movies/Delete/x
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            Movie movie = movieRepo.GetMovie(id);

            if (movie == null) return View("NotFound");

            movieRepo.Delete(movie);
            movieRepo.Save();

            return View("Deleted");
        }
        
        // POST: /Movies/MovieSearch/
        public ActionResult MovieSearch(Movie movie)
        {
            string yearRange = Request.Form["Movie.year_range"];
            string lengthRange = Request.Form["Movie.length_range"];

            var movies = movieRepo.Search(movie.title, yearRange, lengthRange, movie.genre_id, movie.rating_id, null, movie.location_id);
            var pagedMovies = new PaginatedList<Movie>(movies, 0, movies.Count());

            return (Request.IsAjaxRequest()) ? View("MovieList", pagedMovies) : View(pagedMovies);
        }
    }
}
