using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using Backups.Services;
using Zio;
using Zio.FileSystems;
using ZipFile = Ionic.Zip.ZipFile;

namespace Backups.Entities;

public class InMemoryRepository : IRepository
{
    private MemoryFileSystem _fileSystem;
    private List<Storage> _storages;

    public InMemoryRepository(MemoryFileSystem fileSystem, string path)
    {
        _storages = new List<Storage>();
        _fileSystem = fileSystem;
        FullPath = path;
    }

    public string FullPath { get; private set; }

    public IReadOnlyList<Storage> Storages => _storages.AsReadOnly();

    public IReadOnlyCollection<Storage> GetStorages()
    {
        return _storages;
    }

    public void Save(BackupTask backupTask)
    {
        _fileSystem.CreateDirectory(FullPath);
        foreach (Storage storage in backupTask.RestorePoints.Last().Storages)
        {
            _fileSystem.WriteAllBytes("/" + storage.Path, GetBytes(storage.ZipFile));
        }
    }

    public byte[] GetBytes(ZipFile zipFile)
    {
        byte[] buffer;
        int length;
        using (MemoryStream ms = new MemoryStream())
        {
            zipFile.Save(ms);
            buffer = ms.ToArray();
            length = (int)ms.Length;
        }

        return buffer;
    }

    public void WriteAllText(string path, string cont)
    {
        _fileSystem.WriteAllText(path, cont);
    }

    public byte[] ReadAllBytes(string path)
    {
        return _fileSystem.ReadAllBytes(path);
    }
}