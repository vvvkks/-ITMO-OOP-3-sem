using System.Collections.ObjectModel;
using Backups.Entities;
using Backups.Extra.ClearAlgorithms;
using Backups.Extra.Logging;
using Backups.Services;
using Newtonsoft.Json;

namespace Backups.Extra.Entities;

public class ExtraBackupTask : BackupTask
{
    private readonly List<RestorePoint> _restorePoints;
    private readonly ILogging _logging = new ConsoleLogging();
    public ExtraBackupTask(IAlgorithm algorithm, IRepository repository, string name, ILogging logging, ISearchingAlgorithm searchingAlgorithm)
        : base(algorithm, repository, name)
    {
        SearchingAlgorithm = searchingAlgorithm;
        Logging = logging;
        _restorePoints = new List<RestorePoint>();
    }

    public ISearchingAlgorithm SearchingAlgorithm { get; }
    public ILogging Logging { get; }

    public ReadOnlyCollection<RestorePoint> GetRestorePoints()
    {
        _logging.Write("Getting All RestorePoints");
        return _restorePoints.AsReadOnly();
    }
}