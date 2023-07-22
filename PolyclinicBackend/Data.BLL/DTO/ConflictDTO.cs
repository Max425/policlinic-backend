namespace Data.BLL.DTO;

public class ConflictDTO
{
    private static int _lastId = 0;

    public int Id { get; set; }
    public VisitorDTO ConflictPerson { get; set; }
    public string Message { get; set; }

    public ConflictDTO(VisitorDTO conflictPerson, string message)
    {
        ConflictPerson = conflictPerson;
        Message = message;
        Id = ++_lastId;
    }
}