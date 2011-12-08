using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using MovieDB.Models;

namespace MovieDB.Controllers
{
    public class DirectorsController : Controller
    {
        DirectorRepository directorRepo = new DirectorRepository();
        
        // GET: /Directors/
        public ActionResult Index()
        {
            var directors = directorRepo.GetAllDirectors();
            return View(directors);
        }

        // GET: /Directors/Edit/x
        public ActionResult Edit(int id)
        {
            Director director = directorRepo.GetDirector(id);
            return View(director);
        }

        // POST: /Directors/Edit/x
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Director director = directorRepo.GetDirector(id);

            try
            {
                UpdateModel(director);
                directorRepo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddRuleViolations(director.GetRuleViolations());
                return View(director);
            }
        }

        // GET: /Directors/Create/
        public ActionResult Create()
        {
            Director director = new Director();
            return View(director);
        }

        // POST: /Directors/Create/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(director);

                    directorRepo.Add(director);
                    directorRepo.Save();
                    
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddRuleViolations(director.GetRuleViolations());
                }
            }

            return View(director);
        }

        // GET: /Directors/DirectorSearch/
        public ActionResult DirectorSearch(string q, int? limit)
        {
            if (String.IsNullOrEmpty(q)) return Json(new { director_id = -1, FullName = string.Empty });

            var directors = directorRepo.GetAllDirectors().Where(d => d.lname.ToLower().Contains(q));
            var data = from d in directors select new { d.director_id, d.FullName };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: /Directors/CreateModal/
        public ActionResult CreateModal()
        {
            return View(new Director());
        }

        // POST: /Directors/CreateModal/
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateModal(Director director)
        {
            //Request.IsAjaxRequest() && 
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(director);

                    directorRepo.Add(director);
                    directorRepo.Save();
                }
                catch
                {
                    ModelState.AddRuleViolations(director.GetRuleViolations());
                    return View(director);
                }
            }

            return JavaScript("newDirectorComplete('" + director.director_id.ToString() + "', '" + director.FullName + "');");
        }
    }
}
