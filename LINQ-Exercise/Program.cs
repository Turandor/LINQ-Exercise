using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Exercise
{
    class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        delegate bool IsTeenager(Student stud);
        delegate bool IsWanted(Student stud, int age);

        static void Main(string[] args)
        {
            Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Chris",  Age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Rob",Age = 19  } ,
                };

            // Use LINQ to find teenager students
            Student[] teenAgerStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();
            teenAgerStudents.ToList().ForEach(i => Console.WriteLine(i.StudentName.ToString()));
            Console.WriteLine("");
            // Use LINQ to find first student whose name is Bill 
            Student bill = studentArray.Where(s => s.StudentName == "Bill").FirstOrDefault();
            Console.WriteLine(bill.StudentName);
            Console.WriteLine("");
            // Use LINQ to find student whose StudentID is 5
            Student student5 = studentArray.Where(s => s.StudentID == 5).FirstOrDefault();
            Console.WriteLine(student5.StudentName);
            Console.WriteLine("");

            // Use LINQ to find student whose names starts with R
            Student[] studentsNamesR = studentArray.Where
                (s => s.StudentName.StartsWith("R")).ToArray();
            studentsNamesR.ToList().ForEach(i => Console.WriteLine(i.StudentName));
            Console.WriteLine("");
            // or using query syntax
            var studentsNameRR = from s in studentArray
                                 where s.StudentName.StartsWith("R")
                                 select s;
            studentsNameRR.ToList().ForEach(i => Console.WriteLine(i.StudentName));
            Console.WriteLine("");
            // other way af printing output
            foreach (var s in studentsNameRR)
            {
                Console.WriteLine(s.StudentName);
            }
            Console.WriteLine("");

            //delegate
            IsTeenager isTeenager = delegate (Student s) { return s.Age > 12 && s.Age < 20; };
            Student stud = new Student() { Age = 25 };
            Console.WriteLine(isTeenager(stud));

            //delegate with 2 parameters
            IsWanted isWanted = (s, age) => s.StudentName.StartsWith("R") && s.Age >= age;

            // Student collection
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

            Console.WriteLine("");

            var teenAgerStudent = studentList.Where
                (s => s.StudentName.StartsWith("R") && s.Age >= 20);

            Console.WriteLine("Teen age Students:");

            foreach (Student std in teenAgerStudent)
            {
                Console.WriteLine(std.StudentName);
            }
        }
    }
}
