using System;
using System.Collections.Generic;

namespace ShanesSpot.Areas.Todo.Models
{
    public class ToDoEntry
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime DueByDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Category { get; set; }
        public string Location { get; set; }
    }
}