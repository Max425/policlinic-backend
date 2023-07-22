using Data.DAL.Entities;

namespace Data.BLL.DTO;

public class CredentialDTO
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public int OperatorId { get; set; }
    public Operator Operator { get; set; }
}