using Data.DAL.DBExceptions;
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

    public async Task AddSurvey(string title, int price)
    {
        var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault();
        if (p != null)
            throw new ObjectAlreadyExistsException();
        
        var survey = new Survey
        {
            Title = title,
            Price = price
        };
        await _db.Surveys.AddAsync(survey);
        await _db.SaveChangesAsync();
    }

    public async Task EditSurvey(string title, int price)
    {
        var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        p.Title = title;
        p.Price = price;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveSurvey(string title)
    {
        var p = _db.Surveys.Where(p => p.Title == title).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Survey>> GetSurveys()
    {
        return await _db.Surveys.ToListAsync();
    }
}
