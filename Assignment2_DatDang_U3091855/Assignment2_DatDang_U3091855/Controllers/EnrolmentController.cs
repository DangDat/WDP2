using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2_DatDang_U3091855.Models;

namespace Assignment2_DatDang_U3091855.Controllers
{
    public class EnrolmentController : Controller
    {
        MyDBContext db = new MyDBContext();

        //
        // GET: /Enrolment/
        [Authorize(Roles = "Admin,Lecture,Tutor,Student")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Student")]
        public ActionResult Enrol(int id)
        {
            var prevEnrolment = db.Enrolments.Where(x => x.StudentName == User.Identity.Name).FirstOrDefault();

            if (prevEnrolment != null)
            {
                db.Enrolments.Remove(prevEnrolment);
                db.SaveChanges();
            }

            Enrolment enrolment = new Enrolment();
            enrolment.StudentName = User.Identity.Name;
            enrolment.TutorialID = id;
            enrolment.EnrolmentDate = DateTime.Now;

            db.Enrolments.Add(enrolment);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Lecture,Tutor")]
        public ActionResult View(int id)
        {
            List<Enrolment> students = db.Enrolments.Where(x => x.TutorialID == id).ToList();
            return View(students);
        }

        [Authorize(Roles = "Admin,Lecture")]
        public ActionResult Delete(int enrolmentId, int tutorialId)
        {
            var enrolment = db.Enrolments.Find(enrolmentId);

            if (enrolment != null)
            {
                db.Enrolments.Remove(enrolment);
                db.SaveChanges();
            }

            return RedirectToAction("View", new { @id = tutorialId });
        }
    }
}
