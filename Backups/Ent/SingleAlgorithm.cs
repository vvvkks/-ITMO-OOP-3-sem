using Backups.Exception;
using Backups.Services;
using Ionic.Zip;

namespace Backups.Entities;

public class SingleAlgorithm : IAlgorithm
{
    public IEnumerable<Storage> CreateStorages(IReadOnlyCollection<BackupObject> backupObjects, int number, IRepository repository)
    {
        if (backupObjects == null)
            throw new BackupsException("Backup Objects can't be null");
        ZipFile zip = new ZipFile();
        var storages = new List<Storage>();
        foreach (BackupObject backupObject in backupObjects)
        {
            zip.AddItem(backupObject.Name);
        }

        var storage = new Storage($"Archive_{number}.zip", zip);
        foreach (BackupObject backupObject in backupObjects)
        {
            storage.AddBackupObject(backupObject);
        }

        storages.Add(storage);
        return storages;
    }
}