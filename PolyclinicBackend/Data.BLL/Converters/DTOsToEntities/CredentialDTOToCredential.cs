using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public static class CredentialDTOToCredential
{
    public static Credential Convert(CredentialDTO credentialDto)
    {
        var entity = new Credential
        {
            Id = credentialDto.Id,
            Login = credentialDto.Login,
            Password = credentialDto.Password,
            Role = credentialDto.Role,
            OperatorId = credentialDto.OperatorId,
        };
        return entity;
    }
}