using Data.DAL.DBExceptions;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Repositories;

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

        await _db.Operators.AddAsync(p);
        await _db.SaveChangesAsync();
    }

    public async Task EditOperator(string firstName, string lastName, string fatherName)
    {
        var p = _db.Operators.Where(p => p.FirstName == firstName && p.LastName == lastName && 
                            p.FatherName == fatherName).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        p.FirstName = firstName;
        p.LastName = lastName;
        p.FatherName = fatherName;

        await _db.SaveChangesAsync();
    }

    public async Task RemoveOperator(string firstName, string lastName, string fatherName)
    {
        var p = _db.Operators.Where(p => p.FirstName == firstName && p.LastName == lastName && 
                            p.FatherName == fatherName).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Operator>> GetOperators()
    {
        return await _db.Operators.ToListAsync();
    }
}
