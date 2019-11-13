using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Do { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ToDoTeg> Tegs { get; set; }

        public ToDo()
        {
            Tegs = new List<ToDoTeg>();
        }



    }
}
