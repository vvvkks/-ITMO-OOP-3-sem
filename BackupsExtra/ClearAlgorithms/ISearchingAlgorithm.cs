using Backups.Entities;
namespace Backups.Extra.ClearAlgorithms;

public interface ISearchingAlgorithm
{
    List<RestorePoint> GetPoints(List<RestorePoint> restorePoints);
}