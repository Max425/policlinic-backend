using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Service
{
    public class CredentialService
    {
        private CredentialsRepository _credentialsRepository;

        public CredentialService(CredentialsRepository credentialsRepository)
        {
            _credentialsRepository = credentialsRepository;
        }

        public async Task AddCredential(CredentialDTO credentialDTO)
        {
            var entity = CredentialDTOToCredential.Convert(credentialDTO);
            await _credentialsRepository.AddCredential(entity);
        }

        public async Task EditCredential(CredentialDTO credentialDTO)
        {
            var entity = CredentialDTOToCredential.Convert(credentialDTO);
            await _credentialsRepository.EditCredential(entity);
        }

        public async Task RemoveCredential(CredentialDTO credentialDTO)
        {
            var entity = CredentialDTOToCredential.Convert(credentialDTO);
            await _credentialsRepository.RemoveCredential(entity);
        }

        public bool CheckPassword(CredentialDTO credentialDTO)
        {
            var entity = CredentialDTOToCredential.Convert(credentialDTO);
            return _credentialsRepository.CheckPassword(entity);
        }

        public async Task<List<Credential>> GetCredentials()
        {
            return await _credentialsRepository.GetCredentials();
        }

        public Credential GetCredential(CredentialDTO credentialDTO)
        {
            var entity = CredentialDTOToCredential.Convert(credentialDTO);
            return _credentialsRepository.GetCredential(entity);
        }
    }
}
