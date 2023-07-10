using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repositories
{
    public class RecordRepository
    {
        PolyclinicContext _db;
        public RecordRepository(PolyclinicContext polyclinicContext)
        {
            _db = polyclinicContext;
        }

        public async Task AddRecord(Record record)
        {
            var p = _db.Records.Where(p => p.DateTime == record.DateTime && p.SurveyId != 0).FirstOrDefault();
            if (p == null)
            {
                await _db.Records.AddAsync(record);
                await _db.SaveChangesAsync();
            }
        }

        public async Task EditRecord(Record record)
        {
            var p = _db.Records.Where(p => p.DateTime == record.DateTime && p.SurveyId != 0).FirstOrDefault();
            if (p != null)
            {
                p.VisitorId = record.VisitorId;
                p.SurveyId = record.SurveyId;
                p.DateTime = record.DateTime;
                p.OperatorId = record.OperatorId;
                await _db.SaveChangesAsync();
            }
        }

        public async Task RemoveRecord(Record record)
        {
            var p = _db.Records.Where(p => p.DateTime == record.DateTime && p.SurveyId != 0).FirstOrDefault();
            if (p != null)
            {
                _db.Remove(p);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Record>> GetRecords()
        {
            return await _db.Records.ToListAsync();
        }
    }
}
