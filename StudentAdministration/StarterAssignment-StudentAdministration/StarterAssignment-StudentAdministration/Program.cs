using System;
using System.Diagnostics;

namespace StudentAdinistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("John Doe", "SD", 123456);

            Console.WriteLine("Choose your option:" +
                              "\n1. Add a student" +
                              "\n2. View all students" +
                              "\n3. View all groups" +
                              "\n4. Search students by number" +
                              "\n5. Show all students in a group" +
                              "\n6. Show statistics" +
                              "\n7. Exit");
            int option = Console.Read() - '0';
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter student name:");
                    String newStudentName = Console.Read().ToString();
                    Console.WriteLine("Enter student group:");
                    String newStudentGroup = Console.Read().ToString();
                    Console.WriteLine("Enter student PCN:");
                    int newStudentPCN = Console.Read() - '0';
                    Student newStudent = new Student(newStudentName, newStudentGroup, newStudentPCN);
                    Console.WriteLine(newStudent.name + " added to " + newStudent.groupName + " with PCN " + newStudent.pcn);
                    break;
                    
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5: 
                    
                    break;
                case 6:
                    
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
            }


        }
    }

}

