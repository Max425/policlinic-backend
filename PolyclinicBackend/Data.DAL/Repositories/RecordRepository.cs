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

        public void AddRecord(DateTime dateTime, int visitorId, int surveyId)
        {
            var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
            if(p == null)
            {
                var record = new Record
                {
                    VisitorId = visitorId,
                    SurveyId = surveyId,
                    Date = dateTime
                };
                _db.Records.Add(record);
                _db.SaveChanges();
            }
        }

        public void EditRecord(DateTime dateTime, int visitorId, int surveyId)
        {
            var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
            if(p != null)
            {
                p.VisitorId = visitorId;
                p.SurveyId = surveyId;
                p.Date = dateTime;
                _db.SaveChanges();
            }
        }

        public void RemoveRecord(DateTime dateTime, int visitorId, int surveyId)
        {
            var p = _db.Records.Where(p => p.Date == dateTime && p.SurveyId != 0).FirstOrDefault();
            if (p != null)
            {
                _db.Remove(p);
                _db.SaveChanges();
            }
        }
    }
}
