using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public static class DoctorDTOToDoctor
{
    public static Doctor Convert(DoctorDTO recordDto)
    {
        var entity = new Doctor
        {
            FullName = recordDto.FullName,
            CabinetNumber = recordDto.CabinetNumber,
            SurveyId = recordDto.SurveyId,
        };
        return entity;
    }
}
