/*
Author: Gijs van Maanen
Date last modified: 12-02-2025
For: Student administration screen for C# programming

ToDo: 
 - Add class for student actions (add, view, search, etc.)
 - Test the program
 - Clean up everything
*/


namespace StudentAdministration
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose your option:" +
                                  "\n1. Add a student" +
                                  "\n2. View all students" +
                                  "\n3. View all groups" +
                                  "\n4. Search students by number" +
                                  "\n5. Show all students in a group" +
                                  "\n6. Show statistics" +
                                  "\n7. Exit");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewAllStudents();
                        break;
                    case 3:
                        ViewAllGroups();
                        break;
                    case 4:
                        SearchStudentByPCN();
                        break;
                    case 5:
                        ShowStudentsInGroup();
                        break;
                    case 6:
                        ShowStatistics();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("Enter student name:");
            string newStudentName = Console.ReadLine();
            Console.WriteLine("Enter student group:");
            string newStudentGroup = Console.ReadLine();
    
            int newStudentPCN;
            while (true)
            {
                Console.WriteLine("Enter student PCN:");
                string input = Console.ReadLine();
                if (int.TryParse(input, out newStudentPCN))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please fill in a number for PCN.");
                }
            }
    
            Student newStudent = new Student(newStudentName, newStudentGroup, newStudentPCN);
            students.Add(newStudent);
            Console.WriteLine($"{newStudent.name} added to {newStudent.groupName} with PCN {newStudent.pcn}");
        }

        static void ViewAllStudents()
        {
            Console.Clear();
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.name}, Group: {student.groupName}, PCN: {student.pcn}");
            }
        }

        static void ViewAllGroups()
        {
            Console.Clear();
            var groups = new HashSet<string>(students.Select(s => s.groupName));
            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
        }

        static void SearchStudentByPCN()
        {
            Console.Clear();
            Console.WriteLine("Enter student PCN:");
            int pcn = int.Parse(Console.ReadLine());
            var student = students.FirstOrDefault(s => s.pcn == pcn);
            if (student != null)
            {
                Console.WriteLine($"Name: {student.name}, Group: {student.groupName}, PCN: {student.pcn}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void ShowStudentsInGroup()
        {
            Console.Clear();
            Console.WriteLine("Enter group name:");
            string groupName = Console.ReadLine();
            var groupStudents = students.Where(s => s.groupName == groupName);
            foreach (var student in groupStudents)
            {
                Console.WriteLine($"Name: {student.name}, PCN: {student.pcn}");
            }
        }

        static void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine($"Total number of students: {students.Count}");
            var groups = students.GroupBy(s => s.groupName)
                                 .Select(g => new { GroupName = g.Key, Count = g.Count() });
            foreach (var group in groups)
            {
                Console.WriteLine($"Group: {group.GroupName}, Number of students: {group.Count}");
            }
        }
    }
}