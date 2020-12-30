using PhotoBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoBlog.Areas.Admin.Controllers
{
    public class PhotoController : AdminBaseController
    {
        // GET: Admin/Photo
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }

        public ActionResult Add()
        {
            ViewBag.Tags = new MultiSelectList(db.Tags.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(PhotoViewModel photoView, HttpPostedFileBase file, int[] tags)
        {
            Photo photo = new Photo();
            var supportedTypes = new string[] { "jpg", "jpeg", "png" };
            var type = System.IO.Path.GetExtension(file.FileName).ToLower().Replace(".", "");
            if (supportedTypes.Contains(type))
            {
                string delimiter = Guid.NewGuid().ToString();
                string path = @"\UploadedFile\" + delimiter + "_" + file.FileName;
                photo.Head = photoView.Head;
                foreach (var tag in tags)
                {
                    Tag addedTag = db.Tags.FirstOrDefault(x => x.Id == tag);
                    photo.Tags.Add(addedTag);
                }
                photo.Description = photoView.Description;
                photo.Path = path;
                photo.DateTime = DateTime.Now;
                db.Photos.Add(photo);
                db.SaveChanges();
                file.SaveAs(Server.MapPath("~") + path);
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        [HttpPost]
        public ActionResult Delete(Photo photo)
        {
            db.Entry(photo).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            ViewBag.Tags = new MultiSelectList(db.Tags.ToList(), "Id", "Name");

            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        [HttpPost]
        public ActionResult Edit(Photo photo, HttpPostedFileBase file, int[] etiketler)
        {
            ViewBag.Tags = new MultiSelectList(db.Tags.ToList(), "Id", "Name");
            var supportedTypes = new string[] { "jpg", "jpeg", "png" };
            if (file != null)
            {
                var type = System.IO.Path.GetExtension(file.FileName).ToLower().Replace(".", "");
                string delimiter = Guid.NewGuid().ToString();
                string path = @"\UploadedFile\" + delimiter + "_" + file.FileName;
                photo.Path = path;
                file.SaveAs(Server.MapPath("~") + path);
            }
            else
            {
                photo.Path = db.Photos.FirstOrDefault(x => x.Id == photo.Id).Path;
            }
            if (etiketler != null)
            {
                foreach (var tag in etiketler)
                {
                    Tag addedTag = db.Tags.FirstOrDefault(x => x.Id == tag);
                    photo.Tags.Add(addedTag);
                }
            }
            if (photo.Path != "" && photo.Head != "" && photo.Description != "")
            {
                photo.DateTime = DateTime.Now;
                db.Entry(photo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}