using Backups.Entities;

namespace Backups.Extra.ClearAlgorithms;

public class HybridClearAlgorithm : ISearchingAlgorithm
{
    public HybridClearAlgorithm(ISearchingAlgorithm clearByDate, ISearchingAlgorithm clearByAmount)
    {
        ClearByDateAlgorithm = clearByDate;
        ClearByAmountAlgorithm = clearByAmount;
    }

    private ISearchingAlgorithm ClearByDateAlgorithm { get; }
    private ISearchingAlgorithm ClearByAmountAlgorithm { get; }

    public List<RestorePoint> GetPoints(List<RestorePoint> restorePoints)
    {
        var pointsByDate = new List<RestorePoint>();
        var pointsByAmount = new List<RestorePoint>();
        pointsByDate = ClearByDateAlgorithm.GetPoints(restorePoints);
        pointsByAmount = ClearByAmountAlgorithm.GetPoints(restorePoints);
        return pointsByAmount.Union(pointsByDate).ToList();
    }
}