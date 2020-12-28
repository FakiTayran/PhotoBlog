using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoBlog.Models
{
    public class PhotoViewModel
    {
        public string Head { get; set; }

        [Required]
        public string Path { get; set; }

        public string Description { get; set; }

        public ICollection<Tag> Tags { get; set; }

    }
}