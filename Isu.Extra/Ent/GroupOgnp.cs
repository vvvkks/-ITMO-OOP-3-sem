using Isu.Extra.Exception;
namespace Isu.Extra.Enities;

public class GroupOgnp
{
    private const int CountOfMaxStudents = 30;
    private List<IsuExtraStudent> _students;

    public GroupOgnp(string name, CurrentOgnp ognp, string audience, string lector, Schedule schedule)
    {
        if (name == null)
            throw new IsuExtraException("Wrong name");
        if (audience == null)
            throw new IsuExtraException("Wrong audience");
        if (lector == null)
            throw new IsuExtraException("Wrong audience");
        Name = name;
        CurrentOgnp = ognp;
        Audience = audience;
        Lector = lector;
        GroupSchedule = schedule;
        _students = new List<IsuExtraStudent>();
    }

    public string Name { get; }
    public CurrentOgnp CurrentOgnp { get; }
    public string Lector { get; }
    public string Audience { get; }
    public Schedule GroupSchedule { get; }
    public IReadOnlyCollection<IsuExtraStudent> Students => _students;
    public int NumberOfStudents { get; private set; }

    public void AddStudentToOgnpGroup(IsuExtraStudent student)
    {
        if (NumberOfStudents == CountOfMaxStudents)
            throw new IsuExtraException("Group is full");
        NumberOfStudents++;
        _students.Add(student);
    }

    public void RemoveFromOgnpGroup(IsuExtraStudent student)
    {
        if (student == null)
            throw new IsuExtraException("This student hasn't this Ognp");
        NumberOfStudents--;
        _students.Remove(student);
    }

    public List<IsuExtraStudent> GetStudents()
    {
        return _students;
    }
}