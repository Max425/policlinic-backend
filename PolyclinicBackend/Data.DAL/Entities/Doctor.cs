namespace Data.DAL.Entities;

public class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int CabinetNumber { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
}

