using Data.DAL.Context;
using Data.DAL.Entities;

namespace Data.DAL.Repositories;

public class DoctorRepository
{
    private readonly PolyclinicContext _db;

    public DoctorRepository(PolyclinicContext visitorsContext)
    {
        _db = visitorsContext;
    }

    public async Task AddDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        var p = _db.Doctors.Where(p => p.FullName == fullName && p.CabinetNumber == cabinetNumber && p.SurveyId == surveyId).FirstOrDefault();
        if (p == null)
        {
            var doctor = new Doctor
            {
                FullName = fullName,
                CabinetNumber = cabinetNumber,
                SurveyId = surveyId
            };
            await _db.AddAsync(doctor);
            await _db.SaveChangesAsync();
        }
    }

    public async Task EditDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        var p = _db.Doctors.Where(p => p.FullName == fullName && p.CabinetNumber == cabinetNumber && p.SurveyId == surveyId).FirstOrDefault();
        if(p != null)
        {
            p.FullName = fullName;
            p.CabinetNumber = cabinetNumber;
            p.SurveyId = surveyId;
            await _db.SaveChangesAsync();
        }
    }

    public async Task RemoveDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        var p = _db.Doctors.Where(p => p.FullName == fullName && p.CabinetNumber == cabinetNumber && p.SurveyId == surveyId).FirstOrDefault();
        if (p != null)
        {
            _db.Remove(p);
            await _db.SaveChangesAsync();
        }
    }

    public List<Doctor> GetDoctors()
    {
        return _db.Doctors.ToList();
    }
}
