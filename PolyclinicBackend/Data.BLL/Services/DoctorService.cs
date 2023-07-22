using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;

namespace Data.BLL.Services;

public class DoctorService
{
    private readonly DoctorRepository _doctorRepository;

    public DoctorService(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task AddDoctor(DoctorDTO doctorDto)
    {
        var entity = DoctorDTOToDoctor.Convert(doctorDto);
        await _doctorRepository.AddDoctor(entity);
    }

    public async Task EditDoctor(DoctorDTO doctorDto)
    {
        var entity = DoctorDTOToDoctor.Convert(doctorDto);
        await _doctorRepository.EditDoctor(entity);
    }

    public async Task RemoveDoctor(DoctorDTO doctorDto)
    {
        var entity = DoctorDTOToDoctor.Convert(doctorDto);
        await _doctorRepository.RemoveDoctor(entity);
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await _doctorRepository.GetDoctors();
    }
}