namespace Data.DAL.Entities;

public class Credential
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public int OperatorId { get; set; }
    public Operator Operator { get; set; }
}