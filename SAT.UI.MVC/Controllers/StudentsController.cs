using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA.EF;
using SAT.UI.MVC.Utilities;
using SAT.UI.MVC.Models;
using System.Drawing;

namespace SAT.UI.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentStatus);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,LastName,EmailAddress,SSID,StudentImage")] Student student, HttpPostedFileBase StudentImage)
        {
            if (ModelState.IsValid)
            {
                string file = "NoImage.jpg";

                if (StudentImage != null)
                {
                    file = StudentImage.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()) && StudentImage.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;

                        #region Resize Image

                        string savePath = Server.MapPath("~/Content/img/");
                        Image convertedImage = Image.FromStream(StudentImage.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 300;
                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        #endregion
                    }
                    student.StudentImage = file;
                }


                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
    }

    // GET: Students/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Student student = db.Students.Find(id);
        if (student == null)
        {
            return HttpNotFound();
        }
        ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
        return View(student);
    }

    // POST: Students/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "StudentId,FirstName,LastName,EmailAddress,SSID,StudentImage")] Student student, HttpPostedFileBase StudentImage)
    {
        if (ModelState.IsValid)
        {
                string file = "NoImage.jpg";

                if (StudentImage != null)
                {
                    file = StudentImage.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };
                    if (goodExts.Contains(ext.ToLower()) && StudentImage.ContentLength <= 4194304)
                    {
                        file = Guid.NewGuid() + ext;

                        #region Resize Image

                        string savePath = Server.MapPath("~/Content/img/");
                        Image convertedImage = Image.FromStream(StudentImage.InputStream);
                        int maxImageSize = 500;
                        int maxThumbSize = 300;
                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);

                        #endregion
                    }
                    student.StudentImage = file;
                }


                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

    // GET: Students/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Student student = db.Students.Find(id);
        if (student == null)
        {
            return HttpNotFound();
        }
        return View(student);
    }

    // POST: Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Student student = db.Students.Find(id);
            string path = Server.MapPath("~/Content/img/");
            ImageUtility.Delete(path, student.StudentImage);
        db.Students.Remove(student);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
}
