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

    public async Task AddCredential(string login, string password, int operatorId)
    {
        var credential = new Credential
        {
            Login = login,
            Password = password,
            OperatorId = operatorId
        };
        await _db.Credentials.AddAsync(credential);
        await _db.SaveChangesAsync();
    }

    public async Task EditCredential(string login, string password, int operatorId)
    {
        var p = _db.Credentials.Where(p => p.Login == login).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        p.Login = login;
        p.Password = password;
        p.OperatorId = operatorId;

        await _db.SaveChangesAsync();
    }

    public async Task RemoveCredential(string login)
    {
        var p = _db.Credentials.Where(p => p.Login == login).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        _db.Remove(p); 
        await _db.SaveChangesAsync(); 
    }

    public async Task<List<Credential>> GetCredential()
    {
        return await _db.Credentials.ToListAsync();
    }

    public bool CheckPassword(string login, string password)
    {
        var p = _db.Credentials.Where(p => p.Login == login).FirstOrDefault() ?? throw new ObjectNotFoundException();
        return p.Login == login && p.Password == password ? true : false;
    }
}
