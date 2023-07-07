using Data.DAL.Context;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repositories
{
    public class OperatorRepository
    {
        private readonly PolyclinicContext _db;
        public OperatorRepository(PolyclinicContext polyclinicContext)
        {
            _db = polyclinicContext;
        }

        public async Task AddOperator(string firstName, string lastName, string FatherName)
        {
            var p = new Operator
            {
                FirstName = firstName,
                LastName = lastName,
                FatherName = FatherName
            };

            await _db.AddAsync(p);
            await _db.SaveChangesAsync();
        }

        public async Task EditOperator(string firstName, string lastName, string fatherName)
        {
            var p = _db.Operators.Where(p => p.FirstName == firstName && p.LastName == lastName && p.FatherName == fatherName).FirstOrDefault();
            if (p != null)
            {
                p.FirstName = firstName;
                p.LastName = lastName;
                p.FatherName = fatherName;
            }

            await _db.SaveChangesAsync();
        }

        public async Task RemoveOperator(string firstName, string lastName, string fatherName)
        {
            var p = _db.Operators.Where(p => p.FirstName == firstName && p.LastName == lastName && p.FatherName == fatherName).FirstOrDefault();
            if (p != null) { _db.Remove(p); }
            await _db.SaveChangesAsync();
        }
    }
}
