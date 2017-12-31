using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Todo_API.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
