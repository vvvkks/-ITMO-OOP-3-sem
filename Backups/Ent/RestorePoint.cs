using Backups.Exception;
using Backups.Services;
using Ionic.Zip;
namespace Backups.Entities;

public class RestorePoint
{
    public RestorePoint(IEnumerable<Storage> storages, IAlgorithm algorithmI, IRepository repositoryI, int count, string name, string path, DateTime creationDate)
    {
        Path = path;
        CreationDate = creationDate;
        PointName = name + $"_{count}";
        Storages = storages.ToList();
    }

    public string Path { get; }
    public DateTime CreationDate { get; }
    public string PointName { get; }
    public IReadOnlyCollection<Storage> Storages { get; }
    }