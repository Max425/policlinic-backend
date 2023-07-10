using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public class RecordDTOToRecord
{
    public static Record Convert(RecordDTO recordDTO)
    {
        var entity = new Record
        {
            DateTime = recordDTO.Date,
            Id = recordDTO.Id,
            SurveyId = recordDTO.SurveyId,
            VisitorId = recordDTO.VisitorId,
        };
        return entity;
    }
}
