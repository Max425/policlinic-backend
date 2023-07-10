using Data.DAL.Entities;

namespace Data.BLL.DTO;

public class RecordDTO
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int VisitorId { get; set; }
    public int SurveyId { get; set; }
    public int OperatorId { get; set; }
}
