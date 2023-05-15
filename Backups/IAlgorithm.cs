using Backups.Entities;
namespace Backups.Services;

public interface IAlgorithm
{
    IEnumerable<Storage> CreateStorages(IReadOnlyCollection<BackupObject> backupObjects, int number, IRepository repository);
}