using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.EntitiesToDTOs;

public class DoctorToDoctorDTO
{
    public static DoctorDTO Convert(Doctor doctor)
    {
        var DTO = new DoctorDTO
        {
            FullName = doctor.FullName,
            CabinetNumber = doctor.CabinetNumber,
            SurveyId = doctor.SurveyId,
        };
        return DTO;
    }
}
