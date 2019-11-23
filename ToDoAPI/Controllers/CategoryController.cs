using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IServices catService;

        public CategoryController(IServices _catService)
        {
            catService = _catService;
        }

        [HttpGet]
        
        public IEnumerable<CategoryModel> GetAllCategory()
        {
           return catService.GetAllCategory().ToList();
        }

        [HttpPost("{name}")]
        public void AddCategory(string name)
        {
            catService.AddCategory(name);
        }

        [HttpDelete("{id}")]
        public void DeletCategory([FromBody]int id)
        {
            catService.DeleteCategory(id);
        }
    }
}