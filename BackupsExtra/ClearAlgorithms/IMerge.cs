using Backups;
using Backups.Entities;
using Backups.Extra.Entities;

namespace Backups.Extra.ClearAlgorithms;

public interface IMerge
{
    public RestorePoint Clean(ExtraBackupTask backupTaskOld, ExtraBackupTask backupTaskNew, ExtraRestorePoint restorePointOld, ExtraRestorePoint restorePointNew);
}