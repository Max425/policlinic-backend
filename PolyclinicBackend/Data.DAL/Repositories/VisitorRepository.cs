using Data.DAL.Context;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public void AddVisitor(int id, string firstName, string lastName, string fatherName, string city, string gender, 
            DateTime birthDate, string nationality, int passportSeries, int passportNumber, DateTime dateIssue)
        {
            var p = _db.Visitors.Where(q => q.PassportSeries == passportSeries && q.PassportNumber == passportNumber).FirstOrDefault();
            if(p == null)
            {
                var visitor = new Visitor
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FatherName = fatherName,
                    City = city,
                    Gender = gender,
                    BirthDate = birthDate,
                    Nationality = nationality,
                    PassportSeries = passportSeries,
                    PassportNumber = passportNumber,
                    DateIssue = dateIssue
                };

                _db.Visitors.Add(visitor);
                _db.SaveChanges();
            }
        }

        public void EditVisitor(string firstName, string lastName, string fatherName, string city, string gender,
            DateTime birthDate, string nationality, int passportSeries, int passportNumber, DateTime dateIssue)
        {
            var p = _db.Visitors.Where(q => q.PassportSeries == passportSeries && q.PassportNumber == passportNumber).FirstOrDefault();
            if(p != null)
            {
                p.FirstName = firstName;
                p.LastName = lastName;
                p.FatherName = fatherName;
                p.City = city;
                p.Gender = gender;
                p.BirthDate = birthDate;
                p.Nationality = nationality;
                p.PassportNumber = passportNumber;
                p.PassportSeries = passportSeries;
                p.DateIssue = dateIssue;
                _db.SaveChanges();
            }
        }

        public void Remove(int passportSeries, int passportNumber)
        {
            var p = _db.Visitors.Where(q => q.PassportSeries == passportSeries && q.PassportNumber == passportNumber).FirstOrDefault();
            if (p != null) { _db.Visitors.Remove(p); _db.SaveChanges(); }
        }


    }
}
