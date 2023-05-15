namespace Backups.Extra.Logging;

public interface ILogging
{
    void Write(string message, bool isTimecodeOn = false);
}