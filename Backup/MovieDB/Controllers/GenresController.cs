using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using MovieDB.Models;

namespace MovieDB.Controllers
{
    public class GenresController : Controller
    {
        GenreRepository genreRepo = new GenreRepository();

        // GET: /Genres/
        public ActionResult Index()
        {
            var genres = genreRepo.GetAllGenres();
            return View(genres);
        }

        // GET: /Genres/Edit/x
        public ActionResult Edit(int id)
        {
            Genre genre = genreRepo.GetGenre(id);
            return View(genre);
        }

        //POST: /Genres/Edit/x
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Genre genre = genreRepo.GetGenre(id);

            try
            {
                UpdateModel(genre);
                genreRepo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddRuleViolations(genre.GetRuleViolations());
                return View(genre);
            }
        }

        //GET: /Genres/Create/
        public ActionResult Create()
        {
            Genre genre = new Genre();
            return View(genre);
        }

        //POST: /Genres/Create/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(genre);

                    genreRepo.Add(genre);
                    genreRepo.Save();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddRuleViolations(genre.GetRuleViolations());
                }
            }

            return View(genre);
        }
    }
}
