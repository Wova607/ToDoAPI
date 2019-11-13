using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class InitiallDb
    {
        public static void Init(ToDoContext db)
        {

            //init entities
            Category category1 = new Category()
            {
               
                Name = "Work"
            };
            Teg teg1 = new Teg()
            {
               
                Nema = "Project",

            };

            Teg teg2 = new Teg()
            {
               
                Nema = "Task",

            };
            ToDo todo1 = new ToDo()
            {
               
                Header = "DoDb",
                Description = "Create and fill DB",
                ExpireDate = DateTime.Now,
                Do = false,
                CategoryId = category1.Id,
                Category=category1

            };
            ToDoTeg toDoTeg = new ToDoTeg()
            {
                Teg = teg2,
                TegId = teg2.Id,
                ToDo = todo1,
                ToDoId = todo1.Id
            };
            ToDoTeg toDoTeg2 = new ToDoTeg()
            {
                Teg = teg1,
                TegId = teg1.Id,
                ToDo = todo1,
                ToDoId = todo1.Id
            };

            todo1.Tegs.Add(toDoTeg);

            //Db Init

            db.Categories.Add(category1);
            db.Tegs.Add(teg1);
            db.Tegs.Add(teg2);
            db.ToDos.Add(todo1);
            db.ToDoTegs.Add(toDoTeg);
            db.ToDoTegs.Add(toDoTeg2);
            db.SaveChanges();
        }
    }
}
