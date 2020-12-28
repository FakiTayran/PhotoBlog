using PhotoBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoBlog.Areas.Admin.Controllers
{
    public class TagController : AdminBaseController
    {
        // GET: Admin/Tag
        public ActionResult Index()
        {
            return View(db.Tags.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(TagViewModel tagView)
        {
            if (db.Tags.All(x => x.Name != tagView.Name))
            {
                Tag tag = new Tag();
                tag.Name = tagView.Name;
                if (ModelState.IsValid)
                {
                    db.Tags.Add(tag);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        public ActionResult Delete(Tag tag)
        {
            db.Entry(tag).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}