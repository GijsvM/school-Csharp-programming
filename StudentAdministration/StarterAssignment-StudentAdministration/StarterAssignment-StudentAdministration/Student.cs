namespace StudentAdinistration;

public class Student()
{
    public string name { get; set; }
    public string groupName { get; set; }
    public int pcn { get; set; }

    public Student(string name, string groupName, int pcn) : this()
    {
        this.name = name;
        this.groupName = groupName;
        this.pcn = pcn;
    }
}       
