namespace Data.DAL.DBExceptions;

public class ObjectNotFoundException : DBException
{
    public ObjectNotFoundException()
    {
    }

    public ObjectNotFoundException(string message) : base(message)
    {
    }

    public ObjectNotFoundException(Exception ex, string message) : base(ex, message)
    {
    }
}
