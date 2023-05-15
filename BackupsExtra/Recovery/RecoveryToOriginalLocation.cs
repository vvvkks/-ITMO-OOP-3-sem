using Backups.Entities;
using Backups.Extra.Entities;
using Backups.Extra.Logging;

namespace Backups.Extra.Recovery;

public class RecoveryToOriginalLocation : IRecovery
{
    private readonly ILogging _logging = new ConsoleLogging();
    private readonly ExtraRestorePoint _extraRestorePoint;
    public RecoveryToOriginalLocation(ExtraRestorePoint extraRestorePoint)
    {
        _extraRestorePoint = extraRestorePoint;
    }

    public void Recovery()
    {
        var pathToRecovery = new List<string>();
        foreach (ExtraRepository repository in _extraRestorePoint.GetRepositories())
        {
            foreach (Storage file in repository.Storages)
            {
                _logging.Write("Adding path to recovery");
                pathToRecovery.Add(file.Path);
                _logging.Write("Recovery completed");
            }
        }
    }
}