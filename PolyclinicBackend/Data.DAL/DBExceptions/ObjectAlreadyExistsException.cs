namespace Data.DAL.DBExceptions;

public class ObjectAlreadyExistsException : DBException
{
    public ObjectAlreadyExistsException()
    {
    }

    public ObjectAlreadyExistsException(string message) : base(message)
    {
    }
    public ObjectAlreadyExistsException(Exception ex, string message) : base(ex, message)
    {
    }
}
