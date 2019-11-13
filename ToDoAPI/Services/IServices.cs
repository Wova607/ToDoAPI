using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IServices
    {
        List<ToDoModel> GetAllToDo();
        ToDoModel GetToDo(int id);
        List<ToDoModel> GetCategoryToDo(string Category);
        void AddToDo(ToDoModel newToDo);
        void EditToDo(ToDoModel editToDo);
        void DeleteDoTo(int id);


        //work with Category
        List<CategoryModel> GetAllCategory();
        void AddCategory(string name);
        void DeleteCategory(int id);

    }
}
