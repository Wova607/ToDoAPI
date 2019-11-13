using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string ExpireDate { get; set; }
        public bool Do { get; set; }
        public string Category { get; set; }
        public List<string> Tegs { get; set; }
    }
}
