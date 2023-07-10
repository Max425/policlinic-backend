using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Repositories;

public class SurveyRepository
{
    private readonly PolyclinicContext _db;

    public SurveyRepository(PolyclinicContext polyclinicContext)
    {
        _db = polyclinicContext;
    }

    public async Task AddSurvey(Survey survey)
    {
        var p = _db.Surveys.Where(p => p.Title == survey.Title).FirstOrDefault();
        if (p == null)
        {
            await _db.AddAsync(survey);
            await _db.SaveChangesAsync();
        }
    }

    public async Task EditSurvey(Survey survey)
    {
        var p = _db.Surveys.Where(p => p.Title == survey.Title).FirstOrDefault();
        if(p != null)
        {
            p.Title = survey.Title;
            p.Price = survey.Price;
            await _db.SaveChangesAsync();
        }
    }

    public async Task RemoveSurvey(Survey survey)
    {
        var p = _db.Surveys.Where(p => p.Title == survey.Title).FirstOrDefault();
        if (p != null)
        {
            _db.Remove(p);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<List<Survey>> GetSurveys()
    {
        return await _db.Surveys.ToListAsync();
    }
}
