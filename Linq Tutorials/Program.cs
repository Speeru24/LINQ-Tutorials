using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Tutorials
{
    class Program
    {
        public static void printList(IList<Student> studentList)
        {
            foreach (Student std in studentList)
            {
                Console.WriteLine("ID: " + std.StudentID + " Name: " + std.StudentName + " Age: " + std.Age);
            }
        }

        public static void GetLineSeperator()
        {
            Console.WriteLine("\n*********************************************************\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LINQ Tutorials");
            Console.WriteLine("\nStudent List");
            IList<Student> studentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "Shishir", Age=26  },
                new Student() { StudentID = 2, StudentName = "Gaurav", Age=26  },
                new Student() { StudentID = 3, StudentName = "Shubham", Age=20  },
                new Student() { StudentID = 3, StudentName = "Tushar", Age=30  },
                new Student() { StudentID = 3, StudentName = "Ankit", Age=15  },
                new Student() { StudentID = 3, StudentName = "Abhinandan", Age=17  }
            };

            printList(studentList);
            GetLineSeperator();

            Console.WriteLine("Filtering Operator - WHERE");
            GetLineSeperator();



            Console.WriteLine("Student List after applying WHERE clause to display Teenage student\n");
            var filteredList = (from s in studentList
                                where s.Age > 13 && s.Age < 20
                                select s).ToList();
            printList(filteredList);
            Console.WriteLine("\nNote: Here we were getting error cannot convert type IEnumerable<> to List<>. So the solution is to wrap them in Parenthesis and convert to ToList (i.e. ().ToList())\n");
            GetLineSeperator();


            Console.WriteLine("WHERE clause using FUNC type with an anonymous method\n");
            Func<Student, bool> isTeenager = delegate (Student s)
            {
                return s.Age > 12 && s.Age < 20;
            };
            var filteredListUsingAnonymousMethod = (from s in studentList
                                                    where isTeenager(s)
                                                    select s).ToList();

            printList(filteredListUsingAnonymousMethod);
            GetLineSeperator();

            Console.WriteLine("WHERE in LINQ method syntax\n");
            var filteredListLinqMethod = (studentList.Where(s => s.Age > 12 && s.Age < 20)).ToList();
            printList(filteredListLinqMethod);
            GetLineSeperator();



            Console.WriteLine("Filtering Operator - OfType");
            GetLineSeperator();

            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });



            Console.WriteLine("\nTo display only STRING values in a List\n");
            var stringResult = from s in mixedList.OfType<string>()
                               select s;

            foreach (var s in stringResult)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\nTo display only INTEGER values in a List\n");
            var intResult = from s in mixedList.OfType<Int32>()
                            select s;
            foreach (var s in stringResult)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nTo display only OBJECT values in a List\n");
            var stdResult = from s in mixedList.OfType<Student>()
                            select s;

            foreach (var std in stdResult)
            {
                Console.WriteLine(std.StudentName);
            }
            GetLineSeperator();


            IList<Student> studentList2 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };
            Console.WriteLine("Grouping Operator - GroupBy and ToLookup");
            GetLineSeperator();

            var groupedResult = (from std in studentList2
                                 group std by std.Age).ToList();

            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group:{0}", ageGroup.Key);
                foreach(var Name in ageGroup)
                {
                    Console.WriteLine("Student Name: " + Name.StudentName);
                    
                }
            }





            Console.ReadLine();

        }
    }
}
