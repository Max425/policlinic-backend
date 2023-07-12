namespace Data.DAL.DBExceptions;

public class DBException : Exception
{
    public DBException()
    {
    }

    public DBException(string message) : base(message)
    {
    }
}
