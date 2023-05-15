using Backups.Entities;
using Backups.Extra.Entities;
using Backups.Extra.Logging;

namespace Backups.Extra.ClearAlgorithms;

public class Merge : IMerge
{
    private readonly ILogging _logging = new ConsoleLogging();
    public RestorePoint Clean(ExtraBackupTask backupTaskOld, ExtraBackupTask backupTaskNew, ExtraRestorePoint restorePointOld, ExtraRestorePoint restorePointNew)
    {
        var points = new List<ExtraRestorePoint>();
        var algorithm = new SingleAlgorithm();
        if (object.ReferenceEquals(backupTaskOld.GetType(), algorithm.GetType()))
        {
            foreach (ExtraRestorePoint restorePoint in points)
            {
                backupTaskOld.DeleteRestorePoint(restorePoint);
                _logging.Write("Restore Points was deleted");
            }
        }

        if (object.ReferenceEquals(backupTaskNew.GetType(), algorithm.GetType()))
        {
            foreach (ExtraRestorePoint restorePoint in points)
            {
                backupTaskNew.DeleteRestorePoint(restorePoint);
                _logging.Write("Restore Points was deleted");
            }
        }

        if (restorePointNew.GetRepositories().Count == 1 || restorePointOld.GetRepositories().Count == 1)
        {
            if (restorePointOld.GetRepositories()[0].GetStorages().Count != 1 ||
                restorePointNew.GetRepositories()[0].GetStorages().Count != 1)
            {
                if (backupTaskOld.GetRestorePoints().Contains(restorePointOld))
                {
                    backupTaskOld.DeleteRestorePoint(restorePointOld);
                    _logging.Write("Restore Points was deleted");
                    return restorePointNew;
                }
            }
        }

        if (backupTaskOld.GetRestorePoints().Contains(restorePointOld) &&
            !backupTaskNew.GetRestorePoints().Contains(restorePointNew))
        {
            backupTaskOld.DeleteRestorePoint(restorePointOld);
            _logging.Write("Restore Points was deleted");
            backupTaskNew.AddRestorePoint(restorePointOld);
            _logging.Write("Restore Points was added");
        }

        return restorePointOld;
    }
}