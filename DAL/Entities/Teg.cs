using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Teg
    {
        public int Id { get; set; }
        public string Nema { get; set; }
        public virtual ICollection<ToDoTeg> ToDos { get; set; }

        public Teg()
        {
            ToDos = new List<ToDoTeg>();
        }
    }
}
