//
/// class: Student.cs
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
///
///


namespace starterassignment3;

public class Student
{
    private string name;
    private int studentNumber;
    private string groupName;
    
    public string Name { get; }
    public int StudentNumber { get; }
    
    public Student (string name, string groupName, int studentNumber)
    {
        this.name = name;
        this.studentNumber = studentNumber;
        this.groupName = groupName;
    }

    public string GetInfo()
    {
        return $"{name}, {studentNumber}, {groupName}";
    }
}