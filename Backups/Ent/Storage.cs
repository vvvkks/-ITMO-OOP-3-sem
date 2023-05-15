using Backups.Exception;
using Ionic.Zip;
namespace Backups.Entities;

public class Storage
{
    private List<BackupObject> _objects;
    public Storage(string path, ZipFile file)
    {
        if (path == null)
            throw new BackupsException("Wrong path");
        if (file == null)
            throw new BackupsException("Wrong file");
        Path = path;
        ZipFile = file;
        _objects = new List<BackupObject>();
    }

    public string Path { get; }
    public ZipFile ZipFile { get; }
    public IReadOnlyList<BackupObject> BackupObjects => _objects;

    public void AddBackupObject(BackupObject backupObject)
    {
        _objects.Add(backupObject);
    }

    public List<BackupObject> GetFile()
    {
        return _objects;
    }
}