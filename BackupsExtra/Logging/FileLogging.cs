using System.Text.Json;

namespace Backups.Extra.Logging;

public class FileLogging : ILogging
{
    public FileLogging(string filePath)
    {
        FilePath = filePath;
    }

    public string FilePath { get; }

    public void Write(string message, bool isTimecodeOn = false)
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }

        StreamWriter fileStream = File.AppendText(FilePath);
        if (isTimecodeOn)
            fileStream.Write($"{DateTime.Now} + ':' ");
        fileStream.WriteLine(message);
        fileStream.Close();
    }
}