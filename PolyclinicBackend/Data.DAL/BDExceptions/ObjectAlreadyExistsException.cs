namespace Data.DAL.BDExceptions;

class ObjectAlreadyExistsException : Exception
{
    public ObjectAlreadyExistsException()
    {
    }

    public ObjectAlreadyExistsException(string message) : base(message)
    {
    }
}
