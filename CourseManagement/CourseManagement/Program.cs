using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement
{
    class Program
    {
        public static Group[] allGroups = new Group[25];
        static void Main(string[] args)
        {
           
            Teacher teacher1 = new Teacher("Ismayil", "Ismayilov");

            Teacher teacher2 = new Teacher("Samir", "Dadashzade");
            Teacher teacher3 = new Teacher("Yolcu", "Nasib");
            Teacher[] allTeachers = new Teacher[30];
            Group P506 = new Group("p506", "3");
            Group P507 = new Group("p507",  "3");
            allGroups[0] = P506;
            allGroups[1] = P507;
            Student student1 = new Student("Farida", "Ahadli");
            Student student2 = new Student("Ehmed", "Memmedov");
            Student student3 = new Student("Rehim", "Teymurov");
            teacher1.Groups = new Group[] { P506, P507 };
            P506.Students = new Student[] { student1, student2, student3 };
            ShowStudent(P506);
            removeStudent("Ehmed", "Memmedov",P506.Students, P506);
            Console.WriteLine("Telebe silindikden sonra:");
            ShowStudent(P506);
            Options();
        }
        
        public static void Options()
        {
            Console.WriteLine("Choose one of them:\n1.Groups \n2.Students \n3.Teachers");
            string choosing = Console.ReadLine();
            //Console.WriteLine("Choose one of them:\n1.Add\n2.Remove");
            //string operation = Console.ReadLine();
            Checking(choosing);

        }
        public static void Checking(string choosing)
        {
            if(choosing=="1" )
            {
                Console.WriteLine("Onceki qruplar: ");
                ShowGroup(allGroups);
                createGroup();
                Console.WriteLine("Silmek istediyiniz qrupun adini qeyd edin zehmet olmasa:");
                string groupName = Console.ReadLine();
                removeGroup(groupName, allGroups);
                Console.WriteLine("Yeni qruplar: ");
                ShowGroup(allGroups);
             
            }
            if(choosing == "2" )
            {
               //Yoxdur
            }
            if (choosing =="3")
            {
                //Yoxdur
            }
        }
        //Functions for group
        public static void createGroup()
        {
           
            Console.WriteLine("Qrupun adini ve sagird sayini qeyd edin");
            Group newGroup = new Group(Console.ReadLine(),Console.ReadLine());
            for(int i = 0; i < allGroups.Length; i++)
            {
                if (allGroups[i]==default(Group))
                {
                    allGroups[i] = newGroup;
                    Console.WriteLine("yaradilan grup " + allGroups[i].Name);
                    break;
                }
            }
            Console.WriteLine("Zehmet olmasa sagirdlerin ad ve soyadini qeyd edin:");
            for(int i = 0; i < newGroup.Students.Length; i++)
            {
                Console.WriteLine(i + 1 + ". Sagirdin adini ve Soyadini qeyd edin:");
                addStudent(newGroup);
            }
            Console.WriteLine("Group adi: " + newGroup.Name);
            Console.WriteLine("Sagirdler:");
            ShowStudent(newGroup);
            
        }
        public static void ShowGroup(Group[] group)
        {
            
            for (int i = 0; i < group.Length; i++)
            {
                if (group[i ] != default(Group))
                {
                    Console.WriteLine(group[i].Name);


                }
               
            }
        }
      
        public static void removeGroup(string name, Group[] group)
        {
           
            Console.WriteLine("-------------------");
            
               if(findGroup(name, group) > -1)
            {
                group[findGroup(name, group)].Students =new Student[0];
                Console.WriteLine("qrup telebeleri silindiyi ucun telebe qalmayib!");
                ShowStudent(group[findGroup(name, group)]);
                for (int i = findGroup(name, group); i < group.Length - 1; i++)
                {

                    if (group[i + 1] != default(Group))
                    {

                        group[i] = group[i + 1];


                    }
                    else
                    {

                        group[i] = new Group();
                        break;
                    }

                }
                

            }
        }
           
        public static int findGroup(string name,Group[] group )
        {
            for(int i = 0; i < group.Length; i++)
            {
                if (group[i].Name.ToLower() == name.ToLower())
                {
                    return i;

                }


            }
           
                return -1;
            
        }
        //Functions for student
        public static void ShowStudent(Group group)
        {

            for (int i = 0; i < group.Students.Length; i++)
            {
                if (group.Students[i] != default(Student))
                {
                    Console.WriteLine(i+1+". "+group.Students[i].Name+" "+ group.Students[i].Surname);


                }

            }
        }
        public static int findStudent(string name,string surname, Student[] student,Group group)
        {
            for (int i = 0; i < student.Length; i++)
            {
                if (student[i].Name.ToLower() == name.ToLower() && student[i].Surname.ToLower() == surname.ToLower())
                {
                    return i;

                }


            }

            return -1;

        }
        public static void removeStudent(string name, string surname, Student[] student,Group group)
        {
            Console.WriteLine("-------------------");
            if (findStudent(name,surname, student,group) > -1)
            {
                for (int i = findStudent(name,surname, student,group); i < student.Length-1 ; i++)
                {

                    if (student[i + 1] != default(Student))
                    {
                       
                        student[i] = student[i + 1];


                    }
                   
                    else
                    {
                        
                        student[i] = new Student();
                        
                    }
                    if (i + 1 == student.Length - 1)
                    {

                        student[i + 1] = new Student();
                    }

                }

            }
        }
        //Student add elemek qrup yaradilan zaman bas vere biler
        public static void addStudent(Group group)
        {
            Student student = new Student(Console.ReadLine(), Console.ReadLine());
            for (int i = 0; i < group.Students.Length; i++)
            {
                if (group.Students[i] == default(Student))
                {
                    group.Students[i] = student;
                    break;
                }
            }
        }
    }

}
