using PhotoBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoBlog.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected PhotoBlogDbContext db = new PhotoBlogDbContext();
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