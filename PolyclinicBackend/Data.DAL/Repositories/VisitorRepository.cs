using Data.DAL.Context;
using Data.DAL.Entities;

namespace Data.DAL.Repositories;

public class VisitorRepository
{
    public PolyclinicContext _db;

    public VisitorRepository(PolyclinicContext polyclinicContext)
    {
        _db = polyclinicContext;
    }

    public async Task AddVisitor(string firstName, string lastName, string fatherName, string city, string gender, 
        DateTime birthDate, string nationality, int passportSeries, string photoBase64, int passportNumber, DateTime dateIssue)
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
                PhotoBase64 = photoBase64,
                PassportNumber = passportNumber,
                DateIssue = dateIssue
            };

            await _db.Visitors.AddAsync(visitor);
            await _db.SaveChangesAsync();
        }
    }

    public async Task EditVisitor(string firstName, string lastName, string fatherName, string city, string gender,
        DateTime birthDate, string nationality, int passportSeries, string photoBase64, int passportNumber, DateTime dateIssue)
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
            p.PhotoBase64 = photoBase64;
            p.PassportSeries = passportSeries;
            p.DateIssue = dateIssue;
            await _db.SaveChangesAsync();
        }
    }

    public async Task Remove(int passportSeries, int passportNumber)
    {
        var p = _db.Visitors.Where(q => q.PassportSeries == passportSeries && q.PassportNumber == passportNumber).FirstOrDefault();
        if (p != null) { _db.Visitors.Remove(p); await _db.SaveChangesAsync(); }
    }

    public List<Visitor> GetVisitor()
    {
        return _db.Visitors.ToList();
    }
}
