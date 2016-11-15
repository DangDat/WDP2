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
    public class TeachingController : Controller
    {

        private static string fName;
        private MyDBContext db = new MyDBContext();
         [Authorize(Roles = "Admin,Lecture,Tutor,Student")]
        //
        // GET: /Teaching/

        public ActionResult Index()
        {
            return View(db.Teachings.ToList());
        }

        //
        // GET: /Teaching/Details/5

        public ActionResult Details(int id = 0)
        {
            Teaching teaching = db.Teachings.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        //
        // GET: /Teaching/Create
         [Authorize(Roles = "Admin,Lecture")]
        public ActionResult Create()
        {
            //Teaching teach = new Teaching();
            //teach.ReleaseDate = DateTime.Now;
            return View();
        }

        //
        // POST: /Teaching/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase selectedFile, Teaching teaching)
        {
//Teaching teaching = new Teaching();
            if (selectedFile != null && selectedFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(selectedFile.FileName);
                var filePath = Path.Combine(Server.MapPath("~/UploadedFiles/"),
            fileName);
                selectedFile.SaveAs(filePath);
                if (ModelState.IsValid)
                {
                    teaching.Filename = fileName;
                    teaching.ReleaseDate = DateTime.Now;
                    db.Teachings.Add(teaching);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View(teaching);
        }

        //
        // GET: /Teaching/Edit/5
         [Authorize(Roles = "Admin,Lecture")]
        public ActionResult Edit(int id = 0)
        {
            Teaching teaching = db.Teachings.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        //
        // POST: /Teaching/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teaching teaching)
        {
            if (ModelState.IsValid)
            {
                //teaching.Filename = teaching.Filename;
                //teaching.ReleaseDate = teaching.ReleaseDate;
                db.Entry(teaching).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teaching);
        }

        //
        // GET: /Teaching/Delete/5
         [Authorize(Roles = "Admin,Lecture")]
        public ActionResult Delete(int id = 0)
        {
            Teaching teaching = db.Teachings.Find(id);
            if (teaching == null)
            {
                return HttpNotFound();
            }
            return View(teaching);
        }

        //
        // POST: /Teaching/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teaching teaching = db.Teachings.Find(id);
            var filePath = Path.Combine(Server.MapPath("~/UploadedFiles/"),
            teaching.Filename);
            System.IO.File.Delete(filePath);
            db.Teachings.Remove(teaching);
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