using Data.DAL.Context;
using Data.DAL.Entities;

namespace Data.DAL.Repositories;

public class SurveyRepository
{
    private readonly PolyclinicContext _db;

    public SurveyRepository(PolyclinicContext visitorsContext)
    {
        _db = visitorsContext;
    }

    public async Task AddSurvey(string title, int price)
    {
        var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
        if (p == null)
        {
            var survey = new Survey
            {
                Title = title,
                Price = price
            };
            await _db.AddAsync(survey);
            await _db.SaveChangesAsync();
        }
    }

    public async Task EditSurvey(string title, int price)
    {
        var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
        if(p != null)
        {
            p.Title = title;
            p.Price = price;
            await _db.SaveChangesAsync();
        }
    }

    public async Task RemoveSurvey(string title)
    {
        var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
        if (p != null)
        {
            _db.Remove(p);
            await _db.SaveChangesAsync();
        }
    }

    public List<Survey> GetSurveys()
    {
        return _db.Surveys.ToList();
    }
}
