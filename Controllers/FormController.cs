using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            formEntities db = new formEntities();
            User model = new User();
            model.Name = form["firstname"].Trim();
            model.Surname = form["lastname"].Trim();
            model.Identity = form["identity"].Trim();
            model.Email = form["email"].Trim();
            model.Phone = form["cardnumber"].Trim();
            model.City = form["city"].Trim();
            model.Birthday = form["birthday"].Trim();
            model.Photo = form["dosya"].Trim();
            model.Faal = form["faaliyet"].Trim();
            model.Opinion = form["subject"].Trim();
            db.User.Add(model);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(String id)
        {
           
            formEntities db = new formEntities();
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User userInfo = db.User.Find(id);
            if (userInfo.Identity == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(String id)
        {
          
            formEntities db = new formEntities();
            User userInfo = db.User.Find(id);
            db.User.Remove(userInfo);
            db.SaveChanges();
            return RedirectToAction("/Index");
        }

    }
}