using Isu.Models;
using Isu.Tools;

namespace Isu.Entities;

public class Group
{
    public const int CountOfMaxStudents = 30;

    public Group(GroupName newGroup)
    {
        Students = new List<Student>();
        GroupName = newGroup;
        if (newGroup == null)
            throw new ArgumentNullException("Wrong newGroup");
    }

    public GroupName GroupName { get; }
    public List<Student> Students { get; }

    public int NumberOfStudents { get; private set; }

    public void AddStudent(Student student)
    {
        if (NumberOfStudents > CountOfMaxStudents)
            throw new IsuException("Group is full");
        Students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
        NumberOfStudents--;
    }

    public void Add(Student group)
    {
        NumberOfStudents++;
        if (NumberOfStudents > CountOfMaxStudents)
            throw new IsuException("Group is full");
        Students.Add(group);
    }
}
