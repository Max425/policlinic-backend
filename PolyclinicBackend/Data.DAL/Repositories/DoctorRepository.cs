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

    public async Task AddDoctor(Doctor doctor)
    {
        var p = _db.Doctors.Where(p => p.FullName == doctor.FullName && p.CabinetNumber == doctor.CabinetNumber && p.SurveyId == doctor.SurveyId).FirstOrDefault();
        if (p == null)
        {
            await _db.AddAsync(doctor);
            await _db.SaveChangesAsync();
        }
    }

    public async Task EditDoctor(Doctor doctor)
    {
        var p = _db.Doctors.Where(p => p.FullName == doctor.FullName && p.CabinetNumber == doctor.CabinetNumber && p.SurveyId == doctor.SurveyId).FirstOrDefault();
        if(p != null)
        {
            p.FullName = doctor.FullName;
            p.CabinetNumber = doctor.CabinetNumber;
            p.SurveyId = doctor.SurveyId;
            await _db.SaveChangesAsync();
        }
    }

    public async Task RemoveDoctor(Doctor doctor)
    {
        var p = _db.Doctors.Where(p => p.FullName == doctor.FullName && p.CabinetNumber == doctor.CabinetNumber && p.SurveyId == doctor.SurveyId).FirstOrDefault();
        if (p != null)
        {
            _db.Remove(p);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await _db.Doctors.ToListAsync();
    }
}
