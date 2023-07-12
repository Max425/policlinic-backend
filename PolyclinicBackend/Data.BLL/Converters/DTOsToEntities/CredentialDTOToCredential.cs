using Data.BLL.DTO;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Converters.DTOsToEntities
{
    public class CredentialDTOToCredential
    {
        public static Credential Convert(CredentialDTO credentialDTO)
        {
            var entity = new Credential
            {
                Id = credentialDTO.Id,
                Login = credentialDTO.Login,
                Password = credentialDTO.Password,
                Role = credentialDTO.Role,
                OperatorId = credentialDTO.OperatorId,
            };
            return entity;
        }
    }
}
