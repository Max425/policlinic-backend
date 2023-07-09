namespace Data.DAL.BDExceptions;

class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException()
    {
    }

    public ObjectNotFoundException(string message) : base(message)
    {
    }
}
