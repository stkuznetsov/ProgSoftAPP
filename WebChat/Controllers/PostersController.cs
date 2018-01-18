using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;

namespace ChatApplication.Controllers
{
    public class PostersController : Controller
    {

        IRepository repo;
        public PostersController(IRepository r)
        {
            repo = r;
        }

        public ActionResult IndexPost()
        {
            return View(repo.GetPosters());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Poster poster)
        {
            if (string.IsNullOrEmpty(poster.Name))
            {
                ModelState.AddModelError("Name", "Name is empty");
            }
            
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Validation passed";
                repo.Create(poster);
                return RedirectToAction("IndexPost");
            }
            ViewBag.Message = "Request failed validation";
            return RedirectToAction("IndexPost");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Poster poster = repo.Get(id);
            if (poster != null)
                return View(poster);
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("IndexPost");
        }

    }
}