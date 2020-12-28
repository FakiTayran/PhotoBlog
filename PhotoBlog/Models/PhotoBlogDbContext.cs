using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoBlog.Models
{
    public class PhotoBlogDbContext :DbContext
    {
        public PhotoBlogDbContext() : base ("name=PhotoBlogDbContext")
        {

        }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}