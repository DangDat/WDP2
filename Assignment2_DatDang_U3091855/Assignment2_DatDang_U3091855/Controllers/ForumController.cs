using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2_DatDang_U3091855.Models;

namespace Assignment2_DatDang_U3091855.Controllers
{
    public class ForumController : Controller
    {
        private MyDBContext db = new MyDBContext();
        //
        // GET: /Forum/
        [Authorize(Roles = "Admin,Lecture,Tutor,Student")]
        public ActionResult Index()
        {
            return View(db.Forums.ToList());
        }

        [Authorize(Roles = "Admin,Lecture,Tutor,Student")]
        public ActionResult Comment()
        {
            return View(db.Forums.ToList());
        }

        [Authorize(Roles = "Admin,Lecture")]
        public ActionResult Delete(int id = 0)
        {
            Forum forum = db.Forums.Find(id);
            if (forum == null)
            {
                return HttpNotFound();
            }
            return View(forum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum forum = db.Forums.Find(id);
            db.Forums.Remove(forum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult Comment(string txtComments)
        {
            Forum forum = new Forum();
            forum.Posttopic = "Network security";
            forum.Postcomment = txtComments;
            forum.Postname = User.Identity.Name;
            forum.PostDate = DateTime.Now;

            db.Forums.Add(forum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
