using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Models;

namespace Isu.Extra.Enities;

public class Ognp
{
    private readonly List<CurrentOgnp> _current;
    private List<IsuExtraStudent> _students;

    public Ognp(string name, char faculty)
    {
        if (name == null)
            throw new IsuExtraException("Wrong name");
        Name = name;
        Faculty = faculty;
        _current = new List<CurrentOgnp>();
        _students = new List<IsuExtraStudent>();
    }

    public char Faculty { get; set; }
    public string Name { get; }
    public IReadOnlyList<CurrentOgnp> Current => _current;
    public IReadOnlyList<IsuExtraStudent> Students => _students;
    public int NumberOfStudents { get; private set; }

    public List<CurrentOgnp> GetCurrentOgnps()
    {
        return _current;
    }

    public void AddCurrentOgnp(string name, Ognp ognp, Schedule sсhedule, string lector, string audience, char faculty)
    {
        _current.Add(new CurrentOgnp(name, ognp, sсhedule, lector, audience, faculty));
    }
}