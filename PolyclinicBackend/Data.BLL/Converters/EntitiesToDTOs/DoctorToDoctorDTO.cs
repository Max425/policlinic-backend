using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.EntitiesToDTOs;

public static class DoctorToDoctorDTO
{
    public static DoctorDTO Convert(Doctor doctor)
    {
        var dto = new DoctorDTO
        {
            FullName = doctor.FullName,
            CabinetNumber = doctor.CabinetNumber,
            SurveyId = doctor.SurveyId,
        };
        return dto;
    }
}
