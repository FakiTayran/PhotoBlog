using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoBlog.Models
{
    [Table("Photos")]
    public class Photo
    {
        public Photo()
        {
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string Head { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public DateTime? DateTime { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public string TagsName { get { return $"{Tags.Select(x => x.Name).hashtegAndComma()}"; } }
    }
}