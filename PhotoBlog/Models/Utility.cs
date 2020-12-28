using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoBlog.Models
{
    public static class Utility
    {
        public static string hashtegAndComma(this IEnumerable<string> str)
        {
            return string.Join(", #",str);
        }
    }
}