using Data.DAL.Context;
using Data.DAL.Entities;
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

        public async Task AddCredential(string login, string password, int operatorId)
        {
            var credential = new Credential
            {
                Login = login,
                Password = password,
                OperatorId = operatorId
            };
            await _db.AddAsync(credential);
            await _db.SaveChangesAsync();
        }

        public async Task EditCredential(string login, string password, int operatorId)
        {
            var p = _db.Credentials.Where(p => p.Login == login).FirstOrDefault();
            if (p != null)
            {
                p.Login = login;
                p.Password = password;
                p.OperatorId = operatorId;
            }

            await _db.SaveChangesAsync();
        }

        public async Task RemoveCredential(string login)
        {
            var p = _db.Credentials.Where(p => p.Login == login).FirstOrDefault();
            if (p != null) 
            { 
                _db.Remove(p); 
                await _db.SaveChangesAsync(); 
            }
        }

        public bool CheckPassword(string login, string password)
        {
            var p = _db.Credentials.Where(p => p.Login == login).FirstOrDefault();
            if (p != null)
            {
                if(p.Login == login && p.Password == password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
