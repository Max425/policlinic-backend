using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public static class RecordDTOToRecord
{
    public static Record Convert(RecordDTO recordDto)
    {
        var entity = new Record
        {
            DateTime = recordDto.Date,
            Id = recordDto.Id,
            SurveyId = recordDto.SurveyId,
            VisitorId = recordDto.VisitorId,
        };
        return entity;
    }
}
