using Backups.Exception;
using Backups.Services;
namespace Backups.Entities;

public class BackupTask
{
    private string _path;
    private int _count = 1;
    private List<BackupObject> _objects;
    private List<RestorePoint> _restorePoints;

    public BackupTask(IAlgorithm algorithm, IRepository repository, string name)
    {
        Id = Guid.NewGuid();
        _objects = new List<BackupObject>();
        _restorePoints = new List<RestorePoint>();
        _path = repository.FullPath;
        Repository = repository;
        Algorithm = algorithm;
        Name = name;
    }

    public string Name { get; }

    public Guid Id { get; }
    public IReadOnlyList<BackupObject> BackupObjects => _objects;
    public IReadOnlyList<RestorePoint> RestorePoints => _restorePoints;
    public IAlgorithm Algorithm { get; }
    public IRepository Repository { get; }

    public void AddObject(BackupObject backupObject)
    {
        _objects.Add(backupObject);
    }

    public void DeleteObject(BackupObject backupObject)
    {
        _objects.Remove(backupObject);
    }

    public void AddRestorePoint(RestorePoint restorePoint)
    {
        _restorePoints.Add(restorePoint);
    }

    public void DeleteRestorePoint(RestorePoint restorePoint)
    {
        _restorePoints.Remove(restorePoint);
    }

    public void CreateRestorePoint()
    {
        if (_objects == null)
            throw new BackupsException("No files");
        string pointName = RestorePoints.Count != 0 ? RestorePoints.Last().PointName : string.Empty;
        string path = Path.Combine(Repository.FullPath, Name, pointName);
        IEnumerable<Storage> storages = Algorithm.CreateStorages(_objects, _count, Repository);
        _count++;
        _restorePoints.Add(new RestorePoint(storages, Algorithm, Repository, _count, Name, _path, DateTime.Now));
        Repository.Save(this);
    }
}