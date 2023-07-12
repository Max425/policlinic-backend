using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Service
{
    public class DoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task AddDoctor(DoctorDTO doctorDTO)
        {
            var entity = DoctorDTOToDoctor.Convert(doctorDTO);
            await _doctorRepository.AddDoctor(entity);
        }

        public async Task EditDoctor(DoctorDTO doctorDTO)
        {
            var entity = DoctorDTOToDoctor.Convert(doctorDTO);
            await _doctorRepository.EditDoctor(entity);
        }

        public async Task RemoveDoctor(DoctorDTO doctorDTO)
        {
            var entity = DoctorDTOToDoctor.Convert(doctorDTO);
            await _doctorRepository.RemoveDoctor(entity);
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _doctorRepository.GetDoctors();
        }
    }
}
