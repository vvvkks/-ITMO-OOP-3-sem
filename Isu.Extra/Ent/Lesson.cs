using Isu.Extra.Exception;

namespace Isu.Extra;
public class Lesson
{
    private string _start;
    private string _end;

    public Lesson(string start, string end)
    {
        if (start == null)
            throw new IsuExtraException("Wrong start time");
        if (end == null)
            throw new IsuExtraException("Wrong end time");
        _start = start;
        _end = end;
    }
}