using Data.DAL.BDExceptions;
using Data.DAL.Context;
using Data.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL.Repositories;

public class DoctorRepository
{
    private readonly PolyclinicContext _db;

    public DoctorRepository(PolyclinicContext polyclinicContext)
    {
        _db = polyclinicContext;
    }

    public async Task AddDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        var p = _db.Doctors.Where(p => p.FullName == fullName && p.CabinetNumber == cabinetNumber && p.SurveyId == surveyId).FirstOrDefault();
        if (p != null)
            throw new ObjectAlreadyExistsException();
        
        var doctor = new Doctor
        {
            FullName = fullName,
            CabinetNumber = cabinetNumber,
            SurveyId = surveyId
        };
        await _db.Doctors.AddAsync(doctor);
        await _db.SaveChangesAsync();
    }

    public async Task EditDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        var p = _db.Doctors.Where(p => p.FullName == fullName && p.CabinetNumber == cabinetNumber && 
                        p.SurveyId == surveyId).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        p.FullName = fullName;
        p.CabinetNumber = cabinetNumber;
        p.SurveyId = surveyId;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        var p = _db.Doctors.Where(p => p.FullName == fullName && p.CabinetNumber == cabinetNumber && 
                        p.SurveyId == surveyId).FirstOrDefault() ?? throw new ObjectNotFoundException();
        
        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await _db.Doctors.ToListAsync();
    }
}
