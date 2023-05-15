using System.IO.Compression;
using Backups.Exception;
using Backups.Services;
namespace Backups.Entities;

public class Repository : IRepository
{
    private List<Storage> _storages;
    public Repository(string fullPath)
    {
        if (fullPath == null)
            throw new BackupsException("Wrong fullPath");
        FullPath = fullPath;
        _storages = new List<Storage>();
        DirectoryInfo = Directory.CreateDirectory(FullPath);
    }

    public IReadOnlyList<Storage> Storages => _storages;
    public DirectoryInfo DirectoryInfo { get; }

    public string FullPath { get; }

    public void CreateDirectory(string path)
    {
        if (FullPath == null)
            throw new BackupsException("Wrong fullPath");
        Directory.CreateDirectory(FullPath);
    }

    IReadOnlyCollection<Storage> IRepository.GetStorages()
    {
        return Storages;
    }

    public void Save(BackupTask backupTask)
    {
        string path = Path.Combine(DirectoryInfo.FullName, backupTask.Name, backupTask.RestorePoints.Last().PointName);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        foreach (Storage storage in backupTask.RestorePoints.Last().Storages)
        {
            // string tempPath = Path.Combine(path, storage.Path);
            storage.ZipFile.Save();
        }
    }

    public void WriteAllText(string path, string cont)
    {
        File.WriteAllText(path, cont);
    }

    public byte[] ReadAllBytes(string path)
    {
        return File.ReadAllBytes(path);
    }
}