using Data.DAL.Context;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repositories
{
    public class VisitorRepository
    {
        public VisitorsContext _db;

        public VisitorRepository(VisitorsContext db)
        {
            _db = db;
        }

        public void AddVisitor(int id, string firstName, string lastName, string fatherName, string city, string gender)
        {
            var p = _db.Visitors.Where(q => q.Id == id).FirstOrDefault();
            if(p == null)
            {
                var visitor = new Visitor
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    FatherName = fatherName,
                    City = city,
                    Gender = gender
                };
                _db.Visitors.Add(visitor);
                _db.SaveChanges();
            }
        }
    }
}
