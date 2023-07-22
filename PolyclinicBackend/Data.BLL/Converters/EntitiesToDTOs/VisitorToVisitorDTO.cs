using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.EntitiesToDTOs;

public static class VisitorToVisitorDTO
{
    public static VisitorDTO Convert(Visitor visitor)
    {
        var dto = new VisitorDTO
        {
            DateIssue = visitor.DateIssue,
            BirthDate = visitor.BirthDate,
            City = visitor.City,
            FatherName = visitor.FatherName,
            FirstName = visitor.FirstName,
            Gender = visitor.Gender,
            Id = visitor.Id,
            LastName = visitor.LastName,
            Nationality = visitor.Nationality,
            PhotoBase64 = visitor.PhotoBase64,
            PassportNumber = visitor.PassportNumber,
            PassportSeries = visitor.PassportSeries,
        };
        return dto;
    }
}
