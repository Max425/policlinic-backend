namespace Data.DAL.DBExceptions;

public class ObjectNotFoundException : DbException
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
