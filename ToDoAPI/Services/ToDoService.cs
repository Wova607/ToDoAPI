using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public class ToDoService : IServices
    {

        private IRepository<Category> categoryRepository;
        private IRepository<ToDo> toDoRepository;
        private IRepository<ToDoTeg> tegToDoRepository;
        private IRepository<Teg> tegRepository;

        public ToDoService(IRepository<Category> _categoryRepository, IRepository<ToDo> _toDoRepository, IRepository<ToDoTeg> _tegToDoRepository, IRepository<Teg> _tegRepository)
        {
            categoryRepository = _categoryRepository;
            toDoRepository = _toDoRepository;
            tegToDoRepository = _tegToDoRepository;
            tegRepository = _tegRepository;
        }
        public List<ToDoModel> GetAllToDo()
        {
            List<ToDoModel> rez = new List<ToDoModel>();


            foreach (var tD in toDoRepository.GetAllInclude(x => x.Category))
            {
                List<string> teg = new List<string>();
                foreach (var tg in tegToDoRepository.GetAllInclude(x => x.Teg))
                {
                    if (tg.ToDoId==tD.Id)
                    {
                        teg.Add(tg.Teg.Nema);
                    }
                }
                rez.Add(new ToDoModel()
                {
                    Id = tD.Id,
                    Header = tD.Header,
                    Description = tD.Description,
                    ExpireDate = tD.ExpireDate.ToShortDateString(),
                    Do = tD.Do,
                    Category = tD.Category.Name,
                    Tegs = teg

                });
               
            }


            return rez;

        }

        public ToDoModel GetToDo(int id)
        {            
            return   GetAllToDo().FirstOrDefault(x => x.Id == id);         
        }

        public List<ToDoModel> GetCategoryToDo(string Category)
        {            
           return GetAllToDo().Where(x => x.Category == Category).ToList();
        }

        public void AddToDo(ToDoModel newToDo)
        {
            Category cat = categoryRepository.GetAll().FirstOrDefault(x => x.Name == newToDo.Category);
             
            ToDo todo =new ToDo()
            {
                Header = newToDo.Header,
                Description = newToDo.Description,
                Do = newToDo.Do,
                ExpireDate = DateTime.Parse(newToDo.ExpireDate),
                Category = cat,
                CategoryId = cat.Id,
                Tegs = new List<ToDoTeg>()

             };

            foreach (var tg in newToDo.Tegs)
            {
                var teg = tegRepository.GetAll().FirstOrDefault(x => x.Nema == tg);
                if (teg==null)
                {
                    teg = new Teg() { Nema = tg };
                }
                todo.Tegs.Add(new ToDoTeg() { Teg = teg });
            }

            toDoRepository.Add(todo);
        }

        public void EditToDo(ToDoModel editToDo)
        {
            Category cat = categoryRepository.GetAll().FirstOrDefault(x => x.Name == editToDo.Category);

            ToDo todo = new ToDo()
            {
                Header = editToDo.Header,
                Description = editToDo.Description,
                Do = editToDo.Do,
                ExpireDate = DateTime.Parse(editToDo.ExpireDate),
                Category = cat,
                CategoryId = cat.Id,
                Tegs = new List<ToDoTeg>()

            };

            foreach (var tg in editToDo.Tegs)
            {
                var teg = tegRepository.GetAll().FirstOrDefault(x => x.Nema == tg);
                if (teg == null)
                {
                    teg = new Teg() { Nema = tg };
                }
                todo.Tegs.Add(new ToDoTeg() { Teg = teg });
            }

            toDoRepository.Update(todo);
        }

        public void DeleteDoTo(int id)
        {
            toDoRepository.Remove(id);
        }


        //Category 
        public List<CategoryModel> GetAllCategory()
        {
            List<CategoryModel> rez = new List<CategoryModel>();
            foreach (var cat in categoryRepository.GetAll())
            {
                rez.Add(
                    new CategoryModel()
                    {
                        Id = cat.Id,
                        Name = cat.Name
                    });
            }
            return rez;
        }

        public void AddCategory(string name)
        {
            categoryRepository.Add(new Category()
            {
                Name = name

            });
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.Remove(id);
        }


    }
}
