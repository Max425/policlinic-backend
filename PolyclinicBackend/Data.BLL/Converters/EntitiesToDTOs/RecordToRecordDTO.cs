using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.EntitiesToDTOs;

public static class RecordToRecordDTO
{
    public static RecordDTO Convert(Record record)
    {
        var dto = new RecordDTO
        {
            Date = record.DateTime,
            Id = record.Id,
            SurveyId = record.SurveyId,
            VisitorId = record.VisitorId,
        };
        return dto;
    }
}
