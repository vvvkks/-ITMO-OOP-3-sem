using Backups.Entities;
using Ionic.Zip;

namespace Backups.Extra.Entities;

public class ExtraStorage : Storage
{
    public ExtraStorage(string path, ZipFile file)
        : base(path, file)
    {
    }
}