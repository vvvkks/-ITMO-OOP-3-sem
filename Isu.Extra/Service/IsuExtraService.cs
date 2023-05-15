using Isu.Entities;
using Isu.Extra.Enities;
using Isu.Extra.Exception;
using Isu.Models;
using Isu.Services;

namespace Isu.Extra.Services;

public class IsuExtraService : IIsuExtraService
{
    private List<Ognp> _ognps = new List<Ognp>();
    private List<IsuExtraStudent> _students = new List<IsuExtraStudent>();
    private List<IsuExtraGroup> _groups = new List<IsuExtraGroup>();
    private List<CurrentOgnp> _current = new List<CurrentOgnp>();
    private List<GroupOgnp> _groupOgnps = new List<GroupOgnp>();
    private IsuService _service = new IsuService();

    public GroupOgnp AddGroupOgnp(string name, CurrentOgnp ognp, string audience, string lector, Schedule schedule)
    {
        var newGroupOgnp = new GroupOgnp(name, ognp, audience, lector, schedule);
        _groupOgnps.Add(newGroupOgnp);
        return newGroupOgnp;
    }

    public Ognp AddOgnp(string name, char faculty)
    {
        var newOgnp = new Ognp(name, faculty);
        _ognps.Add(newOgnp);
        return newOgnp;
    }

    public CurrentOgnp AddCurrentOgnp(string name, Ognp ognp, Schedule schedule, string lector, string audience, char faculty)
    {
        var newCur = new CurrentOgnp(name, ognp, schedule, lector, audience, faculty);
        _current.Add(newCur);
        return newCur;
    }

    public IsuExtraGroup NewExtraGroup(string name, Schedule schedule)
    {
        Group newGroup = _service.AddGroup(new GroupName(name));
        var extraGroup = new IsuExtraGroup(newGroup, schedule);
        _groups.Add(extraGroup);
        return extraGroup;
    }

    public IsuExtraStudent NewExtraStudent(string name, IsuExtraGroup group)
    {
        Student newStudent = _service.AddStudent(group.Group, name);
        var extraStudent = new IsuExtraStudent(newStudent, group);
        _students.Add(extraStudent);
        return extraStudent;
    }

    public void AddOgnpForStudent(IsuExtraStudent student, CurrentOgnp studentOgnp, GroupOgnp groupOgnp)
    {
        if (groupOgnp.GroupSchedule.GetFirstLesson() == student.IsuExtraGroup.GroupSсhedule.GetFirstLesson())
            throw new IsuExtraException("Wrong time for Ognp");
        if (groupOgnp.GroupSchedule.GetSecondLesson() == student.IsuExtraGroup.GroupSсhedule.GetSecondLesson())
            throw new IsuExtraException("Wrong time for Ognp");
        if (groupOgnp.GroupSchedule.GetThirdLesson() == student.IsuExtraGroup.GroupSсhedule.GetThirdLesson())
            throw new IsuExtraException("Wrong time for Ognp");
        if (studentOgnp.CurrentSchedule.GetFirstLesson() == student.IsuExtraGroup.GroupSсhedule.GetFirstLesson())
            throw new IsuExtraException("Wrong time for Ognp");
        if (studentOgnp.CurrentSchedule.GetSecondLesson() == student.IsuExtraGroup.GroupSсhedule.GetSecondLesson())
            throw new IsuExtraException("Wrong time for Ognp");
        if (studentOgnp.CurrentSchedule.GetThirdLesson() == student.IsuExtraGroup.GroupSсhedule.GetThirdLesson())
            throw new IsuExtraException("Wrong time for Ognp");
        student.AddOgnpForStudent(studentOgnp);
        studentOgnp.AddStudentToOCurrentOgnp(student);
        groupOgnp.AddStudentToOgnpGroup(student);
    }

    public IReadOnlyList<IsuExtraStudent> GetStudents(GroupOgnp groupOgnp)
    {
        return groupOgnp.GetStudents();
    }

    public IReadOnlyList<CurrentOgnp> GetCurrentOgnps(Ognp ognp)
    {
        return ognp.GetCurrentOgnps();
    }

    public IsuExtraStudent RemoveFromOgnpGroup(IsuExtraStudent student, GroupOgnp groupOgnp)
    {
        groupOgnp.RemoveFromOgnpGroup(student);
        return student;
    }

    public IsuExtraStudent RemoveFromCurrentOgnp(IsuExtraStudent student, CurrentOgnp currentOgnp)
    {
        currentOgnp.RemoveFromCurrentOgnp(student);
        return student;
    }

    public IReadOnlyList<IsuExtraStudent> GetStudentsWithoutOgnp(GroupOgnp groupOgnp)
    {
        IReadOnlyList<IsuExtraStudent> freeStudents = groupOgnp.Students.Where(s => groupOgnp is null).ToList();
        return freeStudents;
    }
}