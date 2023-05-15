using Isu.Entities;
using Isu.Tools;

namespace Isu.Models;

public class GroupName
{
    private const int GroupLengthName = 5;
    private const int LowestNumberOfGroup = 0;
    private const int HighestNumberOfGroup = 19;
    public GroupName(string name)
    {
        int numberofcourse = int.Parse(name[2].ToString());
        int firstsymbolofgroup = int.Parse(name[3].ToString());
        int secondsymbolofgroup = int.Parse(name[4].ToString());
        NumberOfGroup = (firstsymbolofgroup * 10) + secondsymbolofgroup;
        Facultet = name[0];
        if (name == null)
            throw new IsuException("Wrong group name");
        FullName = name;
        NumberOfCourse = new CourseNumber(numberofcourse);
        if (FullName.Length != GroupLengthName)
            throw new IsuException("Wrong group name");

        if (NumberOfGroup < LowestNumberOfGroup && NumberOfGroup > HighestNumberOfGroup)
        {
            throw new IsuException("Wrong number of group");
        }
    }

    public int Facultet { get; }
    public CourseNumber NumberOfCourse { get; }
    public int NumberOfGroup { get; }
    public string FullName { get; }
}
