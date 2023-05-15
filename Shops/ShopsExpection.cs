namespace Shops.Expection;

public class ShopsExpection : Exception
{
    public ShopsExpection(string message)
        : base(message)
    {
    }

    public ShopsExpection(string message, Exception innerException)
        : base(message, innerException)
    {
        throw new NotImplementedException();
    }
}