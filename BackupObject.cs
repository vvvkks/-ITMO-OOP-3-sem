using Backups.Exception;
namespace Backups.Entities;
public class BackupObject
{
    public BackupObject(string path = "", string fileName = "")
    {
        var fileInfo = new FileInfo(System.IO.Path.Combine(path, fileName));
        Name = fileInfo.Name;
        Path = path;
        FullName = System.IO.Path.Combine(path, fileName);
    }

    public string Name { get; }
    public string Path { get; }

    public string FullName { get; }
    public bool Exist()
    {
        return File.Exists(Path);
    }
}