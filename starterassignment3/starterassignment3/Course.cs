//
/// class: Course.cs
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
namespace starterassignment3;

public class Course
{
    private List<string> students = new List<string>();
    private int maxGroupCount = 3;

    public string Name { get; set; }
    

    public Student[] Students
    {
        get
        {
            List<Student> tempStudents = new List<Student>();
            foreach (string student in students)
            {
                string[] subString = student.Split(", ");
                if (subString.Length >= 3)
                {
                    string studentName = subString[0];
                    string groupName = subString[1];
                    int studentNumber = Int32.Parse(subString[2]);

                    Student newStudent = new Student(studentName, groupName, studentNumber);
                    tempStudents.Add(newStudent);
                }
            }
            return tempStudents.ToArray();
        }
    }

    public int StudentCount
    {
        get { return students.Count; }
    }

    public int GroupCount
    {
        get
        {
            List<string> groupList = new List<string>();
            foreach (Student student in Students)
            {
                string[] subString = student.GetInfo().Split(", ");
                if (subString.Length >= 3)
                {
                    string groupName = subString[2];
                    if (!groupList.Contains(groupName))
                    {
                        groupList.Add(groupName);
                    }
                }
            }
            return groupList.Count;
        }
    }

    public Course(string name)
    {
        Name = name;
    }
    public bool AddStudent(string name, int studentNumber)
    {
        if (studentNumber <= -1)
        {
            return false;
        }

        foreach (string student in students)
        {
            string[] subString = student.Split(", ");
            if (subString.Length >= 3 && int.Parse(subString[2]) == studentNumber)
            {
                return false;
            }
        }

        List<int> groupNumbers = new List<int>();
        foreach (string student in students)
        {
            string[] subString = student.Split(", ");
            if (subString.Length >= 2)
            {
                string groupName = subString[1];
                string[] parts = groupName.Split('_');
                if (parts.Length > 0 && parts[0].Length > 2)
                {
                    string groupNr = parts[0].Substring(2);
                    if (int.TryParse(groupNr, out int groupNumber))
                    {
                        groupNumbers.Add(groupNumber);
                    }
                }
            }
        }

        if (groupNumbers.Count >= maxGroupCount)
        {
            List<int> lastThree = new List<int>();
            for (int i = groupNumbers.Count - maxGroupCount; i < groupNumbers.Count; i++)
            {
                lastThree.Add(groupNumbers[i]);
            }

            bool allEqual = true;
            for (int i = 1; i < lastThree.Count; i++)
            {
                if (lastThree[i] != lastThree[0])
                {
                    allEqual = false;
                    break;
                }
            }

            if (allEqual)
            {
                groupNumbers.Add(lastThree.Last() + 1);
            }
            else
            {
                groupNumbers.Add(lastThree.Last());
            }
        }
        else
        {
            groupNumbers.Add(1);
        }
        string newGroupName = $"PG{groupNumbers.Last()}_PCS2";

        try
        {
            students.Add($"{name}, {newGroupName}, {studentNumber}");
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public Student SearchByStudentnumber(int query)
    {
        foreach (Student student in Students)
        {
            if (int.Parse(student.GetInfo().Split(", ")[1]) == query)
            {
                return student;
            }
        }
        return null;    
    }

    public Student[] SearchByGroup(string query)
    {
        List<Student> studentsInGroup = new List<Student>();
        foreach (Student student in Students)
        {
            if (student.GetInfo().Split(", ")[2] == query)
            {
                studentsInGroup.Add(student);
            }
        }
        return studentsInGroup.ToArray();    
    }
}