using Isu.Entities;
using Isu.Models;

namespace Isu.Extra.Enities;
public class IsuExtraGroup
{
    public IsuExtraGroup(Group group, Schedule sсhedule)
    {
        Group = group;
        GroupSсhedule = sсhedule;
    }

    public Group Group { get; }
    public Schedule GroupSсhedule { get; }
}