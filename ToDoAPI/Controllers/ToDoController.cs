using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private IServices toDoService;

        public ToDoController(IServices _toDoService)
        {
            toDoService = _toDoService;
        }


        [HttpGet]
        public IEnumerable<ToDoModel> GetAllToDo()
        {

            return toDoService.GetAllToDo();
        }

        [HttpGet("{id}")]
        public ToDoModel GetToDo(int id)
        {
            return toDoService.GetToDo(id);
        }

        [HttpGet("{Category}")]
        public IEnumerable<ToDoModel> GetCategoryToDo(string Category)
        {
            return toDoService.GetCategoryToDo(Category);
        }


        [HttpPost]
        public void AddToDo(ToDoModel newTodo)
        {
            toDoService.AddToDo(newTodo);
        }

       
        [HttpPut]
        public void EditTodo(ToDoModel editeToDo)
        {
            toDoService.EditToDo(editeToDo);
        }

        [HttpDelete]
        public void DeleteTodo(int id)
        {
            toDoService.DeleteDoTo(id);
        }       

        

    }
}
