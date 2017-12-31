using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core_Todo_API.Models;
using System.Net.Http;
using System.Net;
using System.Web;

namespace Core_Todo_API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet(Name = "GetAll")]
        public IEnumerable<Todo> Get()
        {
            return TodoContext.TodoList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            return TodoContext.TodoList[id];
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Boolean completed)
        {
            TodoContext.TodoList.Single(x => x.Id == id).Completed = completed;

            return new OkResult();
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Todo todo)
        {
            if (!ModelState.IsValid)
                return new BadRequestResult();

            if (String.IsNullOrEmpty(todo.Title))
                return new BadRequestResult();

            todo.Id = TodoContext.GetNewId();
            todo.Title = HttpUtility.HtmlEncode(todo.Title);

            TodoContext.TodoList.Add(todo);
            return new ObjectResult(todo);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            /*if (TodoContext.TodoList.ElementAtOrDefault(id) == null)
                return new NotFoundResult();*/

            TodoContext.TodoList.Remove(TodoContext.TodoList.Single(x => x.Id == id));
            return new OkResult();
        }
    }
}
