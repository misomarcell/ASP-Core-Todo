using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Todo_API.Models
{
    public static class TodoContext
    {
        //public TodoContext(DbContextOptions<TodoContext> options)
        //    : base(options)
        //{
        //}

        //public DbSet<Todo> Todos { get; set; }

        public static List<Todo> TodoList{ get; set; }

        static TodoContext()
        {
            TodoList = new List<Todo>();
            TodoList.Add(new Todo() { Id=0, Title="Teszt", Completed=false });
        }

        public static int GetNewId()
        {
            int newId = 0;
            while (TodoList.Any(x => x.Id == newId)) {
                newId++;
            }
            return newId;
        }
    }
}
