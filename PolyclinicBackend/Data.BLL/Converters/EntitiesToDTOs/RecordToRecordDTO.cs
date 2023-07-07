using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.EntitiesToDTOs;

public class RecordToRecordDTO
{
    public static RecordDTO Convert(Record record)
    {
        var DTO = new RecordDTO
        {
            Date = record.Date,
            Id = record.Id,
            SurveyId = record.SurveyId,
            VisitorId = record.VisitorId,
        };
        return DTO;
    }
}
