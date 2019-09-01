using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    class Group
    {
        public string Name { get; set; }
        
        public Student[] Students;
        
        public Group(string name, string count)
        {
            this.Name = name;
          
            Students = new Student[Convert.ToInt32(count)];
        }
        public Group()
        {
            
        }
    }
}
