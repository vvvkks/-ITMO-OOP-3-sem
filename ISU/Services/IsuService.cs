using Isu.Entities;
using Isu.Models;
using Isu.Tools;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private readonly List<Group> _groups = new List<Group>();
    private readonly List<Student> _students = new List<Student>();
    private int _studentId = 1;
    public Group AddGroup(GroupName name)
    {
        var group = new Group(name);
        _groups.Add(group);
        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        if (group == null)
        {
            throw new ArgumentNullException("Wrong group");
        }

        if (name == null)
        {
            throw new ArgumentNullException("Wrong name");
        }

        var student = new Student(name, group, group.GroupName, _studentId);
        _studentId++;
        _students.Add(student);
        group.Add(student);
        return student;
    }

    public Student GetStudent(int id)
    {
        return
            _students.FirstOrDefault(student => student.Id == id) ??
               throw new IsuException("Wrong id");
    }

    public Student? FindStudent(int id)
    {
        return _students.FirstOrDefault(student => student.Id == id);
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        return _students.FindAll(s => s.Group.GroupName == groupName);
    }

    public List<Group> FindStudents(CourseNumber courseNumber)
    {
        return _groups.FindAll(g => g.GroupName.NumberOfCourse == courseNumber);
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.FirstOrDefault(group => group.GroupName == groupName);
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        return _groups.FindAll(s => s.GroupName.NumberOfCourse == courseNumber);
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        student.Group.RemoveStudent(student);
        newGroup.AddStudent(student);
        student.Group = newGroup;
    }
}
