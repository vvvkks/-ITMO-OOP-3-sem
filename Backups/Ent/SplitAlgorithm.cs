using Backups.Exception;
using Backups.Services;
using Ionic.Zip;

namespace Backups.Entities;

public class SplitAlgorithm : IAlgorithm
{
    public IEnumerable<Storage> CreateStorages(IReadOnlyCollection<BackupObject> backupObjects, int number, IRepository repository)
    {
        if (backupObjects == null)
            throw new BackupsException("Backup Objects can't be null");
        var storages = new List<Storage>();
        foreach (BackupObject backupObject in backupObjects)
        {
            ZipFile zip = new ZipFile();
            zip.AddEntry(backupObject.Name, repository.ReadAllBytes(backupObject.FullName));
            var storage = new Storage(backupObject.Name + $"_{number}.zip", zip);
            storage.AddBackupObject(backupObject);
            storages.Add(storage);
        }

        return storages;
    }
}