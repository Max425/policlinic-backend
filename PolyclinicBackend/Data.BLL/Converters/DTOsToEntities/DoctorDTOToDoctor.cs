using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public class DoctorDTOToDoctor
{
    public static Doctor Convert(DoctorDTO recordDTO)
    {
        var entity = new Doctor
        {
            FullName = recordDTO.FullName,
            CabinetNumber = recordDTO.CabinetNumber,
            SurveyId = recordDTO.SurveyId,
        };
        return entity;
    }
}
