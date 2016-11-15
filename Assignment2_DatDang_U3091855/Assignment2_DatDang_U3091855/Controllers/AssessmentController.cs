using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2_DatDang_U3091855.Models;
using System.IO;

namespace Assignment2_DatDang_U3091855.Controllers
{
    public class AssessmentController : Controller
    {
        private MyDBContext db = new MyDBContext();

        //
        // GET: /Assessment/
        [Authorize(Roles = "Admin,Lecture,Tutor,Student")]
        public ActionResult Index()
        {
            return View(db.Assessments.ToList());
        }

        //
        // GET: /Assessment/Details/5

        public ActionResult Details(int id = 0)
        {
            Assessment assessment = db.Assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        //
        // GET: /Assessment/Create
        [Authorize(Roles = "Student")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Assessment/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase selectedFile,Assessment assessment)
        {
            if (selectedFile != null && selectedFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(selectedFile.FileName);
                var filePath = Path.Combine(Server.MapPath("~/UploadedFiles/"),
            fileName);
                selectedFile.SaveAs(filePath);
                if (ModelState.IsValid)
                {
                    assessment.AssessmentDate = DateTime.Now;
                    assessment.AssessmentLink = fileName;
                    assessment.AssessmentGrade = -1;
                    db.Assessments.Add(assessment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(assessment);
        }

        //
        // GET: /Assessment/Edit/5
        [Authorize(Roles = "Admin,Lecture,Tutor")]
        public ActionResult Edit(int id = 0)
        {
            Assessment assessment = db.Assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        //
        // POST: /Assessment/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assessment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assessment);
        }

        //
        // GET: /Assessment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Assessment assessment = db.Assessments.Find(id);
            if (assessment == null)
            {
                return HttpNotFound();
            }
            return View(assessment);
        }

        //
        // POST: /Assessment/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assessment assessment = db.Assessments.Find(id);
            db.Assessments.Remove(assessment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DownloadFile(string fileName)
        {
            Response.ContentType = "APPLICATION/OCTET-STREAM";
            string Header = "Attachment; Filename=" + fileName;
            Response.AppendHeader("Content-Disposition", Header);
            string filePath = Server.MapPath("~/UploadedFiles/" + fileName);
            Response.WriteFile(filePath);
            Response.End();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}