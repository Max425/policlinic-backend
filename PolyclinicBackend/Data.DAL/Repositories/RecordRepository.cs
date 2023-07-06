using Data.DAL.Context;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repositories
{
    public class RecordRepository
    {
        VisitorsContext _db;
        public RecordRepository(VisitorsContext visitorsContext)
        {
            _db = visitorsContext;
        }

        public async Task AddRecord(DateTime dateTime, int visitorId, int surveyId, int operatorId)
        {
            var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
            if (p == null)
            {
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
        }

        public async Task EditRecord(DateTime dateTime, int visitorId, int surveyId, int operatorId)
        {
            var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
            if (p != null)
            {
                p.VisitorId = visitorId;
                p.SurveyId = surveyId;
                p.Date = dateTime;
                p.OperatorId = operatorId;
                await _db.SaveChangesAsync();
            }
        }

        public async Task RemoveRecord(DateTime dateTime)
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
}
