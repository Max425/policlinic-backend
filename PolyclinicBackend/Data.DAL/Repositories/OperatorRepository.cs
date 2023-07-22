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

    public async Task AddOperator(Operator oper)
    {
        var p = _db.Operators
            .FirstOrDefault(p => p.FirstName == oper.FirstName && p.LastName == oper.LastName && p.FatherName == oper.FatherName);
        if (p != null)
            throw new ObjectAlreadyExistsException();
        await _db.AddAsync(oper);
        await _db.SaveChangesAsync();
    }

    public async Task EditOperator(Operator oper)
    {
        var p = _db.Operators.FirstOrDefault(p => p.Id == oper.Id) ?? throw new ObjectNotFoundException();
        p.FirstName = oper.FirstName;
        p.LastName = oper.LastName;
        p.FatherName = oper.FatherName;

        await _db.SaveChangesAsync();
    }

    public async Task RemoveOperator(Operator oper)
    {
        var p = _db.Operators
            .FirstOrDefault(p => p.FirstName == oper.FirstName && p.LastName == oper.LastName && p.FatherName == oper.FatherName) ?? throw new ObjectNotFoundException();
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Operator>> GetOperators()
    {
        return await _db.Operators.ToListAsync();
    }
}