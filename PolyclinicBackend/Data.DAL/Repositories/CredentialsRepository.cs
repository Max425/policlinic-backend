using Data.DAL.DBExceptions;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Repositories;

public class CredentialsRepository
{
    private readonly PolyclinicContext _db;
    public CredentialsRepository(PolyclinicContext polyclinicContext)
    {
        _db = polyclinicContext;
    }

    public async Task AddCredential(Credential credential)
    {
        var p = _db.Credentials.Where(p => p.Login == credential.Login).FirstOrDefault();
        if (p != null)
            throw new ObjectAlreadyExistsException();
        await _db.AddAsync(credential);
        await _db.SaveChangesAsync();
    }

    public async Task EditCredential(Credential credential)
    {
        var p = _db.Credentials.Where(p => p.Id == credential.Id).FirstOrDefault() ?? throw new ObjectNotFoundException();;

        p.Login = credential.Login;
        p.Password = credential.Password;
        p.Role = credential.Role;
        p.OperatorId = credential.OperatorId;       
        await _db.SaveChangesAsync();
    }

    public async Task RemoveCredential(Credential credential)
    {
        var p = _db.Credentials.Where(p => p.Login == credential.Login).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        _db.Remove(p); 
        await _db.SaveChangesAsync(); 
    }

    public Credential GetCredential(Credential credential)
    {
        return _db.Credentials.Where(p => p.Login == credential.Login && p.Password == credential.Password).FirstOrDefault();
    }
    
    public async Task<List<Credential>> GetCredentials()
    {
        return await _db.Credentials.ToListAsync();
    }

    public bool CheckPassword(Credential credential)
    {
        var p = _db.Credentials.Where(p => p.Login == credential.Login).FirstOrDefault() ?? throw new ObjectNotFoundException();
        return p.Login == credential.Login && p.Password == credential.Password ? true : false;
    }
}
