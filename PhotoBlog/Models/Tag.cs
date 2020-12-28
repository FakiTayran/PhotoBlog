using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoBlog.Models
{
    [Table("Tags")]
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public override string ToString()
        {
            return Name; 
        }
    }
}