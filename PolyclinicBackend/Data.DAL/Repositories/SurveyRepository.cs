using Data.DAL.Context;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Repositories
{
    public class SurveyRepository
    {
        private readonly VisitorsContext _db;

        public SurveyRepository(VisitorsContext visitorsContext)
        {
            _db = visitorsContext;
        }

        public void AddSurvey(string title, int price)
        {
            var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
            if (p == null)
            {
                var survey = new Survey
                {
                    Title = title,
                    Price = price
                };
                _db.Add(survey);
                _db.SaveChanges();
            }
        }

        public void EditSurvey(string title, int price)
        {
            var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
            if(p != null)
            {
                p.Title = title;
                p.Price = price;
                _db.SaveChanges();
            }
        }

        public void RemoveSurvey(string title)
        {
            var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
            if (p != null)
            {
                _db.Remove(p);
                _db.SaveChanges();
            }
        }
    }
}
