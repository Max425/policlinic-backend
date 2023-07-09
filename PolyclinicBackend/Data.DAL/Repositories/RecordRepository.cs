using Data.DAL.BDExceptions;
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

    public async Task AddRecord(DateTime dateTime, int visitorId, int surveyId, int operatorId)
    {
        var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
        if (p != null)
            throw new ObjectAlreadyExistsException();
            
        var record = new Record
        {
            VisitorId = visitorId,
            SurveyId = surveyId,
            Date = dateTime,
            OperatorId = operatorId
        };
        await _db.Records.AddAsync(record);
        await _db.SaveChangesAsync();
    }

    public async Task EditRecord(DateTime dateTime, int visitorId, int surveyId, int operatorId)
    {
        var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault() 
            ?? throw new ObjectNotFoundException();
            
        p.VisitorId = visitorId;
        p.SurveyId = surveyId;
        p.Date = dateTime;
        p.OperatorId = operatorId;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveRecord(DateTime dateTime)
    {
        var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault() 
            ?? throw new ObjectNotFoundException();
            
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Record>> GetRecord()
    {
        return await _db.Records.ToListAsync();
    }
}
