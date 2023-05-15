using System.Collections.ObjectModel;
using Backups.Entities;
using Backups.Extra.Logging;
using Backups.Services;

namespace Backups.Extra.Entities;

public class ExtraRestorePoint : RestorePoint
{
    private readonly ILogging _logging = new ConsoleLogging();
    private List<ExtraRepository> _repositories;
    public ExtraRestorePoint(IEnumerable<Storage> storages, IAlgorithm algorithmI, IRepository repositoryI, int count, string name, string path, DateTime creationDate)
        : base(storages, algorithmI, repositoryI, count, name, path, creationDate)
    {
        _repositories = new List<ExtraRepository>();
    }

    public ReadOnlyCollection<ExtraRepository> GetRepositories()
    {
        _logging.Write("Getting repositories");
        return _repositories.AsReadOnly();
    }
}