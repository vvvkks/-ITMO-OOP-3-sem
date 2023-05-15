namespace Backups.Extra.Logging;

public class ConsoleLogging : ILogging
{
    public void Write(string message, bool isTimecodeOn = false)
    {
        Console.WriteLine($"{DateTime.Now} | message + ':' ");
    }
}
