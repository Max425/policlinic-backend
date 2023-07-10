using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddOperator(Operator oper)
        {
            await _db.AddAsync(oper);
            await _db.SaveChangesAsync();
        }

        public async Task EditOperator(Operator oper)
        {
            var p = _db.Operators.Where(p => p.FirstName == oper.FirstName && p.LastName == oper.LastName && p.FatherName == oper.FatherName).FirstOrDefault();
            if (p != null)
            {
                p.FirstName = oper.FirstName;
                p.LastName = oper.LastName;
                p.FatherName = oper.FatherName;
            }

            await _db.SaveChangesAsync();
        }

        public async Task RemoveOperator(Operator oper)
        {
            var p = _db.Operators.Where(p => p.FirstName == oper.FirstName && p.LastName == oper.LastName && p.FatherName == oper.FatherName).FirstOrDefault();
            if (p != null) { _db.Remove(p); }
            await _db.SaveChangesAsync();
        }

        public async Task<List<Operator>> GetOperators()
        {
            return await _db.Operators.ToListAsync();
        }
    }
}
