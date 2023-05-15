using System.Diagnostics.Metrics;
using Isu.Models;

namespace Isu.Entities;

public class Student
{
    public Student(string name, GroupName newGroup, Group group, int id)
    {
        Name = name;
        Group = group;
        Id = id;
        if (name == null)
            throw new ArgumentNullException("Wrong name");
        if (newGroup == null)
            throw new ArgumentNullException("Wrong newGroup");
        if (group == null)
            throw new ArgumentNullException("Wrong group");
    }

    public Student(string name, Group group, GroupName groupName, int studentId)
    {
        Name = name;
        Group = group;
        if (name == null)
            throw new ArgumentNullException("Wrong name");
        if (group == null)
            throw new ArgumentNullException("Wrong group");
        if (groupName == null)
            throw new ArgumentNullException("Wrong groupName");
    }

    public int Id { get; }
    public string Name { get; }
    public Group Group { get; set; }
    public GroupName GroupName => Group.GroupName;
}