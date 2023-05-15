using Isu.Entities;
using Isu.Tools;

namespace Isu.Models;

public class CourseNumber
{
    private const int MaxCourseNumber = 4;
    private const int MinCourseNumber = 1;
    public CourseNumber(int courseNumber)
    {
        if (courseNumber < MinCourseNumber || courseNumber > MaxCourseNumber)
        {
            throw new IsuException("Invalid Course number");
        }
    }
}
