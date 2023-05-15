using Isu.Extra.Enities;
using Isu.Extra.Exception;

namespace Isu.Extra.Services;
public interface IIsuExtraService
{
    Ognp AddOgnp(string name, char faculty);
    IsuExtraGroup NewExtraGroup(string name, Schedule schedule);
    IsuExtraStudent NewExtraStudent(string name, IsuExtraGroup group);
    GroupOgnp AddGroupOgnp(string name, CurrentOgnp ognp, string audience, string lector, Schedule schedule);
    void AddOgnpForStudent(IsuExtraStudent student, CurrentOgnp studentOgnp, GroupOgnp groupOgnp);
    CurrentOgnp AddCurrentOgnp(string name, Ognp ognp, Schedule schedule, string lector, string audience, char faculty);
    IReadOnlyList<CurrentOgnp> GetCurrentOgnps(Ognp ognp);
    IsuExtraStudent RemoveFromOgnpGroup(IsuExtraStudent student, GroupOgnp groupOgnp);
    IsuExtraStudent RemoveFromCurrentOgnp(IsuExtraStudent student, CurrentOgnp currentOgnp);
    IReadOnlyList<IsuExtraStudent> GetStudents(GroupOgnp groupOgnp);
    IReadOnlyList<IsuExtraStudent> GetStudentsWithoutOgnp(GroupOgnp groupOgnp);
}