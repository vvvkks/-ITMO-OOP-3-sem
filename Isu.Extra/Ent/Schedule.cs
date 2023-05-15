using Isu.Extra.Exception;

namespace Isu.Extra;

public class Schedule
{
    public Schedule(WeekDay lessonDay, Lesson first, Lesson second, Lesson third, Lesson rest)
    {
        if (first == null)
            throw new IsuExtraException("Wrong lesson");
        if (second == null)
            throw new IsuExtraException("Wrong lesson");
        if (third == null)
            throw new IsuExtraException("Wrong lesson");
        if (rest == null)
            throw new IsuExtraException("Wrong rest");
        Day = lessonDay;
        First = first;
        Second = second;
        Third = third;
        Rest = rest;
    }

    private WeekDay Day { get; }
    private Lesson First { get; }
    private Lesson Third { get; }
    private Lesson Second { get; }
    private Lesson Rest { get; }

    public WeekDay GetDay()
    {
        return Day;
    }

    public Lesson GetFirstLesson()
    {
        return First;
    }

    public Lesson GetSecondLesson()
    {
        return Second;
    }

    public Lesson GetThirdLesson()
    {
        return Third;
    }
}