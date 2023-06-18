using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } 
    }
}

