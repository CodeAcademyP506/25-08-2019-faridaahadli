using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    class Teacher
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group[] Groups;
        
        public Teacher(string name, string surname,int count=3)
        {

            this.Name = name;
            this.Surname = surname;
            this.Groups = new Group[count];
        }
        public Teacher() { }
    }
}
