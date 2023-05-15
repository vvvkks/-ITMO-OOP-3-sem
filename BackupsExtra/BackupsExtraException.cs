namespace Backups.Extra.Exception;

public class BackupsExtraException : System.Exception
{
    public BackupsExtraException(string message)
            : base(message)
        {
        }

    public BackupsExtraException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
}
