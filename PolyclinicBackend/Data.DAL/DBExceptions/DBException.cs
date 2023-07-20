namespace Data.DAL.DBExceptions;

public class DBException : Exception
{
    public DBException()
    {
    }

    public DBException(string message) : base(message)
    {
    }

    public DBException(Exception ex, string message) : base(message, ex)
    {
    }
}
