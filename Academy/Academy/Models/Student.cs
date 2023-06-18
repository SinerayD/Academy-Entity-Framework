using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Student : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}

