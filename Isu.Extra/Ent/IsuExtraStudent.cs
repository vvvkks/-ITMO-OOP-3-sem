using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Models;

namespace Isu.Extra.Enities;

public class IsuExtraStudent : IEquatable<IsuExtraStudent>
{
    private readonly List<CurrentOgnp> _current;
    public IsuExtraStudent(Student student, IsuExtraGroup group)
    {
        Student = student;
        IsuExtraGroup = group;
        _current = new List<CurrentOgnp>();
        StudentOgnp = null;
    }

    public Student Student { get; }

    public IReadOnlyList<CurrentOgnp> Current => _current;
    public CurrentOgnp? StudentOgnp { get; private set; }

    public IsuExtraGroup IsuExtraGroup { get; }

    public void AddOgnpForStudent(CurrentOgnp studentOgnp)
    {
        if (studentOgnp == null)
            throw new IsuExtraException("Ognp is null");
        if (studentOgnp != null && Student.GroupName.Facultet == studentOgnp.Faculty)
            throw new IsuExtraException("Wrong ognp1");
        if (studentOgnp != null)
        {
            _current.Add(studentOgnp);
            StudentOgnp = studentOgnp;
        }
    }

    public bool Equals(IsuExtraStudent? other)
        => other is not null && other.Student.Id.Equals(Student.Id);

    public override bool Equals(object? obj)
    {
        return Equals(obj as IsuExtraStudent);
    }

    public override int GetHashCode()
    {
        return Student.Id.GetHashCode();
    }
}