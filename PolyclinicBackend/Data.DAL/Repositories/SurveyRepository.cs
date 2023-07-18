using Data.DAL.DBExceptions;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        if (p != null)
            throw new ObjectAlreadyExistsException();
        await _db.Surveys.AddAsync(survey);
        await _db.SaveChangesAsync();
    }

    public async Task EditSurvey(Survey survey)
    {
        var p = _db.Surveys.Where(p => p.Id == survey.Id).FirstOrDefault() ?? throw new ObjectNotFoundException();
        p.Title = survey.Title;
        p.Price = survey.Price;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveSurvey(Survey survey)
    {
        var p = _db.Surveys.Where(p => p.Title == survey.Title).FirstOrDefault() ?? throw new ObjectNotFoundException();
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Survey>> GetSurveys()
    {
        return await _db.Surveys.ToListAsync();
    }
    public async Task<Survey> GetSurveyById(int id)
    {
        return await _db.Surveys.FirstOrDefaultAsync(p => p.Id == id) ?? throw new ObjectNotFoundException();
    }
}
