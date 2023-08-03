namespace Data.DAL.DBExceptions;

public class DbException : Exception
{
    protected DbException()
    {
    }

    protected DbException(string message) : base(message)
    {
    }

    protected DbException(Exception ex, string message) : base(message, ex)
    {
    }
}
