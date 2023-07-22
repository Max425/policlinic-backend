using Data.DAL.DBExceptions;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Repositories;

public class RecordRepository
{
    private readonly PolyclinicContext _db;

    public RecordRepository(PolyclinicContext polyclinicContext)
    {
        _db = polyclinicContext;
    }

    public async Task AddRecord(Record record)
    {
        var p = _db.Records.FirstOrDefault(p => p.DateTime == record.DateTime && p.SurveyId == record.VisitorId);
        if (p != null)
            throw new ObjectAlreadyExistsException();
        await _db.Records.AddAsync(record);
        await _db.SaveChangesAsync();
    }

    public async Task EditRecord(Record record)
    {
        var p = _db.Records.FirstOrDefault(p => p.Id == record.Id) ?? throw new ObjectNotFoundException();
        p.VisitorId = record.VisitorId;
        p.SurveyId = record.SurveyId;
        p.DateTime = record.DateTime;
        p.OperatorId = record.OperatorId;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveRecord(Record record)
    {
        var p = _db.Records.FirstOrDefault(p => p.DateTime == record.DateTime && p.SurveyId == record.VisitorId) ??
                throw new ObjectNotFoundException();
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Record>> GetRecords()
    {
        return await _db.Records.ToListAsync();
    }

    public async Task<List<Record>> GetRecordsByVisitorId(int id)
    {
        return await _db.Records.Where(p => p.VisitorId == id).ToListAsync();
    }
}