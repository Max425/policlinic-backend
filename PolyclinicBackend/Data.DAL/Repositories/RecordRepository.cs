using Data.DAL.Context;
using Data.DAL.Entities;

namespace Data.DAL.Repositories;

public class RecordRepository
{
    PolyclinicContext _db;
    public RecordRepository(PolyclinicContext visitorsContext)
    {
        _db = visitorsContext;
    }

    public async Task AddRecord(DateTime dateTime, int visitorId, int surveyId)
    {
        var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
        if (p == null)
        {
            var record = new Record
            {
                VisitorId = visitorId,
                SurveyId = surveyId,
                Date = dateTime
            };
            await _db.Records.AddAsync(record);
            await _db.SaveChangesAsync();
        }
    }

    public async Task EditRecord(DateTime dateTime, int visitorId, int surveyId)
    {
        var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
        if (p != null)
        {
            p.VisitorId = visitorId;
            p.SurveyId = surveyId;
            p.Date = dateTime;
            await _db.SaveChangesAsync();
        }
    }

    public async Task RemoveRecord(DateTime dateTime, int visitorId, int surveyId)
    {
        var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
        if (p != null)
        {
            _db.Remove(p);
            await _db.SaveChangesAsync();
        }
    }

    public List<Record> GetRecord()
    {
        return _db.Records.ToList();
    }
}
