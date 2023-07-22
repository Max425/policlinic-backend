using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;

namespace Data.BLL.Services;

public class CredentialService
{
    private readonly CredentialsRepository _credentialsRepository;

    public CredentialService(CredentialsRepository credentialsRepository)
    {
        _credentialsRepository = credentialsRepository;
    }

    public async Task AddCredential(CredentialDTO credentialDto)
    {
        var entity = CredentialDTOToCredential.Convert(credentialDto);
        await _credentialsRepository.AddCredential(entity);
    }

    public async Task EditCredential(CredentialDTO credentialDto)
    {
        var entity = CredentialDTOToCredential.Convert(credentialDto);
        await _credentialsRepository.EditCredential(entity);
    }

    public async Task RemoveCredential(CredentialDTO credentialDto)
    {
        var entity = CredentialDTOToCredential.Convert(credentialDto);
        await _credentialsRepository.RemoveCredential(entity);
    }

    public bool CheckPassword(CredentialDTO credentialDto)
    {
        var entity = CredentialDTOToCredential.Convert(credentialDto);
        return _credentialsRepository.CheckPassword(entity);
    }

    public async Task<List<Credential>> GetCredentials()
    {
        return await _credentialsRepository.GetCredentials();
    }

    public Credential GetCredential(CredentialDTO credentialDto)
    {
        var entity = CredentialDTOToCredential.Convert(credentialDto);
        return _credentialsRepository.GetCredential(entity);
    }
}