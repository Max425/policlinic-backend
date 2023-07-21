using Data.DAL.DBExceptions;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Repositories;

public class VisitorGeneratedRepository
{
    private readonly GeneratedContext _db;

    public VisitorGeneratedRepository(GeneratedContext generatedContext)
    {
        _db = generatedContext;
    }

    public async Task AddVisitor(Visitor visitor)
    {
        var p = _db.VisitorsGenerated.Where(q => q.PassportSeries == visitor.PassportSeries && q.PassportNumber == visitor.PassportNumber).FirstOrDefault();
        if(p != null)
            throw new ObjectAlreadyExistsException();
        await _db.VisitorsGenerated.AddAsync(visitor);
        await _db.SaveChangesAsync();
    }

    public async Task EditVisitor(Visitor visitor)
    {
        var p = _db.VisitorsGenerated.Where(q => q.Id == visitor.Id).FirstOrDefault() ?? throw new ObjectNotFoundException();
        p.FirstName = visitor.FirstName;
        p.LastName = visitor.LastName;
        p.FatherName = visitor.FatherName;
        p.City = visitor.City;
        p.Gender = visitor.Gender;
        p.BirthDate = visitor.BirthDate;
        p.Nationality = visitor.Nationality;
        p.PassportNumber = visitor.PassportNumber;
        p.PhotoBase64 = visitor.PhotoBase64;
        p.PassportSeries = visitor.PassportSeries;
        p.DateIssue = visitor.DateIssue;
        await _db.SaveChangesAsync();
    }

    public async Task Remove(Visitor visitor)
    {
        var p = _db.VisitorsGenerated.Where(q => q.PassportSeries == visitor.PassportSeries && q.PassportNumber == visitor.PassportNumber).FirstOrDefault() ?? throw new ObjectNotFoundException();
        _db.VisitorsGenerated.Remove(p);     
        await _db.SaveChangesAsync();
    }

    public async Task<List<Visitor>> GetVisitorGenerated(int batchSize, int skipCount)
    {
        return await _db.VisitorsGenerated
            .Skip(skipCount)
            .Take(batchSize)
            .ToListAsync();
    }
}
