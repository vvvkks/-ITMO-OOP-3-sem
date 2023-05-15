using Backups.Entities;

namespace Backups.Services;

public interface IRepository
{
    string FullPath { get; }
    byte[] ReadAllBytes(string path);
    void WriteAllText(string path, string cont);
    public IReadOnlyCollection<Storage> GetStorages();
    void Save(BackupTask backupTask);
}