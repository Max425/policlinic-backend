using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public class VisitorDTOToVisitor
{
    public static Visitor Convert(VisitorDTO visitorDTO)
    {
        var entity = new Visitor
        {
            BirthDate = visitorDTO.BirthDate,
            City = visitorDTO.City,
            DateIssue = visitorDTO.DateIssue,
            FatherName = visitorDTO.FatherName,
            FirstName = visitorDTO.FirstName,
            Gender = visitorDTO.Gender,
            Id = visitorDTO.Id,
            LastName = visitorDTO.LastName,
            Nationality = visitorDTO.Nationality,
            PhotoBase64 = visitorDTO.PhotoBase64,
            PassportNumber = visitorDTO.PassportNumber,
            PassportSeries = visitorDTO.PassportSeries
        };
        return entity;
    }
}
