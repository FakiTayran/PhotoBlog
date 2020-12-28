using PhotoBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoBlog.Controllers
{
    public class HomeController : Controller
    {
        PhotoBlogDbContext db = new PhotoBlogDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Photos.ToList());
        }
    }
}