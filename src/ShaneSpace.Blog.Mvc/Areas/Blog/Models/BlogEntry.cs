using System;
using System.ComponentModel.DataAnnotations;

namespace ShanesSpot.Areas.Blog.Models
{
    public class BlogEntry
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public string Link { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}