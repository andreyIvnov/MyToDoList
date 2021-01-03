using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoList.Model
{
    public class Job
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool IsDone { get; set; }

        public DateTime DueDate { get; set; }
    }
}
