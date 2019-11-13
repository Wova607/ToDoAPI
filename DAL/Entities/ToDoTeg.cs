using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ToDoTeg
    {
        public int ToDoId { get; set; }

        public virtual ToDo ToDo { get; set; }
        public int TegId { get; set; }
        public Teg Teg { get; set; }
    }
}
    