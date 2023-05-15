using System.Collections.ObjectModel;
using Backups.Entities;
using Backups.Extra.Logging;

namespace Backups.Extra.Entities;

public class ExtraRepository : Repository
{
    private readonly ILogging _logging = new ConsoleLogging();
    private List<Storage> _storages;
    public ExtraRepository(string fullPath)
        : base(fullPath)
    {
        _storages = new List<Storage>();
    }

    public ReadOnlyCollection<Storage> GetStorages()
    {
        _logging.Write("Getting storages");
        return _storages.AsReadOnly();
    }
}