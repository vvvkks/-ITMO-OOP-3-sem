using Backups.Entities;
using Backups.Extra.Exception;
using Backups.Extra.Logging;

namespace Backups.Extra.ClearAlgorithms;

public class ClearByAmount : ISearchingAlgorithm
{
    private readonly int _limitAmount;

    public ClearByAmount(int amount)
    {
        if (amount <= 0)
        {
            throw new BackupsExtraException("Amount can't be zero or less");
        }

        _limitAmount = amount;
    }

    public List<RestorePoint> GetPoints(List<RestorePoint> restorePoints)
    {
        var restorePointsToSave = new List<RestorePoint>();
        int count = restorePoints.Count - _limitAmount;
        var points = restorePointsToSave.Take(count).ToList();
        return points;
    }
}