using Backups.Entities;

namespace Backups.Extra.ClearAlgorithms;

public class ClearByDate : ISearchingAlgorithm
{
    private readonly DateTime _timeLimit;

    public ClearByDate(DateTime dateTime)
    {
        _timeLimit = dateTime;
    }

    public List<RestorePoint> GetPoints(List<RestorePoint> restorePoints)
    {
        var restorePointsToInclude =
            restorePoints.Where(restorePoint => restorePoint.CreationDate > _timeLimit).ToList();
        return restorePointsToInclude;
    }
}