using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repositories
{
    public class CredentialsRepository
    {
        private readonly PolyclinicContext _db;
        public CredentialsRepository(PolyclinicContext polyclinicContext)
        {
            _db = polyclinicContext;
        }

        public async Task AddCredential(Credential credential)
        {
            await _db.AddAsync(credential);
            await _db.SaveChangesAsync();
        }

        public async Task EditCredential(Credential credential)
        {
            var p = _db.Credentials.Where(p => p.Login == credential.Login).FirstOrDefault();
            if (p != null)
            {
                p.Login = credential.Login;
                p.Password = credential.Password;
                p.Role = credential.Role;
                p.OperatorId = credential.OperatorId;
            }

            await _db.SaveChangesAsync();
        }

        public async Task RemoveCredential(Credential credential)
        {
            var p = _db.Credentials.Where(p => p.Login == credential.Login).FirstOrDefault();
            if (p != null) 
            { 
                _db.Remove(p); 
                await _db.SaveChangesAsync(); 
            }
        }

        public bool CheckPassword(Credential credential)
        {
            var p = _db.Credentials.Where(p => p.Login == credential.Login).FirstOrDefault();
            if (p != null)
            {
                if(p.Login == credential.Login && p.Password == credential.Password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<List<Credential>> GetCredentials()
        {
            return await _db.Credentials.ToListAsync();
        }

        public Credential GetCredential(Credential credential)
        {
            return _db.Credentials.Where(p => p.Login == credential.Login && p.Password == credential.Password).FirstOrDefault();
        }
    }
}
