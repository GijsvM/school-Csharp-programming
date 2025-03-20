//
/// class: Program.cs
/// description: StudentAdministration is a Console app that allows users to:
/// add students, view all students, view all groups, search students by number, show all students in a group and show statistics
/// This program is created for teachers to add students to different groups of 3 students.
///
/// Name: Gijs van Maanen
/// Studentnumber: 548495
/// Date: 18 March 2025
///
///Version: 2.0
///

namespace starterassignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("Course 1");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. View all groups");
                Console.WriteLine("4. Search students by number");
                Console.WriteLine("5. Show all students in a group");
                Console.WriteLine("6. Show statistics");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter student number: ");
                        int newStudentNumber = int.Parse(Console.ReadLine());
                        if (course.AddStudent(name, newStudentNumber))
                        {
                            Console.WriteLine("Student added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add student.");
                        }
                        break;
                    case "2":
                        List<Student> viewStudents = course.Students.ToList();
                        foreach (Student student in viewStudents)
                        {
                            Console.WriteLine(student.GetInfo());
                        }
                        break;
                    case "3":
                        List<string> groupNames = GetGroupNames(course.Students);
                        foreach (string group in groupNames)
                        {
                            Console.WriteLine(group);
                        }
                        break;

                        
                    case "4":
                        Console.Write("Enter student number: ");
                        int studentNumber = int.Parse(Console.ReadLine());
                        Student foundStudent = course.SearchByStudentnumber(studentNumber);
                        if (foundStudent != null)
                        {
                            Console.WriteLine(foundStudent.GetInfo());
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter group name: ");
                        string groupNameSearch = Console.ReadLine();
                        List<Student> studentsInGroup = course.SearchByGroup(groupNameSearch).ToList();
                        foreach (Student student in studentsInGroup)
                        {
                            Console.WriteLine(student.GetInfo());
                        }
                        break;
                    case "6":
                        PrintCourseInfo(course);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                

                static List<string> GetGroupNames(IEnumerable<Student> students)
                {
                    List<string> groupNames = new List<string>();
                    foreach (Student student in students)
                    {
                        string groupName = student.GetInfo().Split(", ")[2];
                        if (!string.IsNullOrEmpty(groupName) && !groupNames.Contains(groupName))
                        {
                            groupNames.Add(groupName);
                        }
                    }
                    return groupNames;
                }
                static void PrintCourseInfo(Course course)
                {
                    Console.WriteLine($"{course.Name}");
                    Console.WriteLine($"Number of distinct students: {course.StudentCount}");
                    Console.WriteLine($"Number of distinct groups: {course.GroupCount}");
                }
            }
        }
    }
}