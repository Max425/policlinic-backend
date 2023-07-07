namespace Data.DAL.Entities;

public class Record
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int VisitorId { get; set; }
    public Visitor Visitor { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
    public int OperatorId { get; set; }
    public Operator Operator { get; set; }
}
