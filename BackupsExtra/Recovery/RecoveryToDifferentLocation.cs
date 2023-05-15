using Backups.Entities;
using Backups.Extra.Entities;
using Backups.Extra.Logging;

namespace Backups.Extra.Recovery;

public class RecoveryToDifferentLocation : IRecovery
{
    private readonly ILogging _logging = new ConsoleLogging();
    private readonly ExtraRestorePoint _extraRestorePoint;

    public RecoveryToDifferentLocation(ExtraRestorePoint extraRestorePoint)
    {
        _extraRestorePoint = extraRestorePoint;
    }

    public void Recovery()
    {
        var pathToRecovery = new List<string>();
        if (!Directory.Exists(pathToRecovery.ToString()))
        {
            Directory.CreateDirectory(pathToRecovery.ToString() !);
        }

        foreach (ExtraRepository repository in _extraRestorePoint.GetRepositories())
        {
            foreach (Storage file in repository.Storages)
            {
                _logging.Write("Adding path to recovery");
                pathToRecovery.Add(file.Path);
            }
        }

        var specifiedDirectory = new DirectoryInfo(pathToRecovery.ToString() !);
        specifiedDirectory.Create();
        _logging.Write("Specified Directory was created");
    }
}