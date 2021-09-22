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

        public IHttpActionResult GetToDo()
        {

        }

        public IHttpActionResult PostToDo()
        {

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