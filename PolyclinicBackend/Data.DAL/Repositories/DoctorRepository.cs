using Data.DAL.DBExceptions;
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
        var p = _db.Doctors
            .FirstOrDefault(p => p.FullName == doctor.FullName && p.CabinetNumber == doctor.CabinetNumber &&
                                 p.SurveyId == doctor.SurveyId);
        if (p != null) throw new ObjectAlreadyExistsException();
        await _db.Doctors.AddAsync(doctor);
        await _db.SaveChangesAsync();
    }

    public async Task EditDoctor(Doctor doctor)
    {
        var p = _db.Doctors.FirstOrDefault(p => p.Id == doctor.Id) ?? throw new ObjectNotFoundException();
        p.FullName = doctor.FullName;
        p.CabinetNumber = doctor.CabinetNumber;
        p.SurveyId = doctor.SurveyId;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveDoctor(Doctor doctor)
    {
        var p = _db.Doctors
            .FirstOrDefault(p => p.FullName == doctor.FullName && p.CabinetNumber == doctor.CabinetNumber &&
                                 p.SurveyId == doctor.SurveyId) ?? throw new ObjectNotFoundException();

        _db.Remove(p);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await _db.Doctors.ToListAsync();
    }
}