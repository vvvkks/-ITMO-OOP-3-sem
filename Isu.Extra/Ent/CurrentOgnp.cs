using Isu.Extra.Exception;
namespace Isu.Extra.Enities;

public class CurrentOgnp
{
    private const int CountOfMaxStudents = 100;
    private List<GroupOgnp> _groupOgnps;
    private List<IsuExtraStudent> _students;

    public CurrentOgnp(string name, Ognp ognp, Schedule schedule, string lector, string audience, char faculty)
    {
        if (name == null)
            throw new IsuExtraException("Wrong name");
        if (audience == null)
            throw new IsuExtraException("Wrong audience");
        if (lector == null)
            throw new IsuExtraException("Wrong audience");
        Name = name;
        CurrOgnp = ognp;
        Audience = audience;
        Lector = lector;
        CurrentSchedule = schedule;
        _groupOgnps = new List<GroupOgnp>();
        _students = new List<IsuExtraStudent>();
        Faculty = faculty;
    }

    public char Faculty { get; }

    public string Name { get; }
    public Ognp CurrOgnp { get; }
    public string Lector { get; }
    public string Audience { get; }
    public Schedule CurrentSchedule { get; set; }
    public IReadOnlyList<GroupOgnp> GroupOgnp => _groupOgnps;
    public IReadOnlyList<IsuExtraStudent> Students => _students;
    public int NumberOfStudents { get; private set; }

    public void AddStudentToOCurrentOgnp(IsuExtraStudent student)
    {
        if (NumberOfStudents == CountOfMaxStudents)
            throw new IsuExtraException("Current is full");
        NumberOfStudents++;
        _students.Add(student);
    }

    public void RemoveFromCurrentOgnp(IsuExtraStudent student)
    {
        if (student == null)
            throw new IsuExtraException("This student hasn't this Ognp");
        NumberOfStudents--;
        _students.Remove(student);
    }
}
