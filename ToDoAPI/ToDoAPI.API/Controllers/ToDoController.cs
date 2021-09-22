using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using ToDoAPI.DATA.EF;
using ToDoAPI.API.Models;
using System.Web.Http.Cors;

namespace ToDoAPI.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ToDoController : ApiController
    {
        ToDoEntities db = new ToDoEntities();
       
        public IHttpActionResult GetToDos()
        {
            //List<ToDoItemViewModel> todos = db.ToDoItems.Include("Category").Select(t => new ToDoItemViewModel() { }).ToList();

            List<ToDoItemViewModel> todos = db.ToDoItems.Include("Category").Select(t => new ToDoItemViewModel()
            {
                TodoId = t.TodoId,
                Action = t.Action,
                Done = t.Done,
                CategoryId = t.CategoryId,
                Category = new CategoryViewModel()
                {
                    CategoryId = t.Category.CategoryId,
                    Name = t.Category.Name,
                    Description = t.Category.Description
                }

            }).ToList<ToDoItemViewModel>();

            if (todos.Count == 0)
            {
                return NotFound();
            }

            return Ok(todos);
        }

        public IHttpActionResult GetToDo(int id)
        {
            ToDoItemViewModel todo = db.ToDoItems.Include("Category").Where(t => t.TodoId == id).Select(t => new ToDoItemViewModel()
            {
                //Assign the parameters of the Resources coming from the db to a Data Transfer Object
                TodoId = t.TodoId,
                Action = t.Action,
                Done = t.Done,
                CategoryId = t.CategoryId,
                Category = new CategoryViewModel()
                {
                    CategoryId = t.Category.CategoryId,
                    Name = t.Category.Name,
                    Description = t.Category.Description
                }
            }).FirstOrDefault();

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        public IHttpActionResult PostToDo(ToDoItemViewModel todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

             ToDoItem newToDo = new ToDoItem()
            {
                 TodoId = todo.TodoId,
                 Action = todo.Action,
                 Done = todo.Done,
                 CategoryId = todo.CategoryId,
             };

            db.ToDoItems.Add(newToDo);
            db.SaveChanges();
            return Ok(newToDo);
        }

        public IHttpActionResult PutToDo()
        {

        }

        public IHttpActionResult DeleteToDo()
        {

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}