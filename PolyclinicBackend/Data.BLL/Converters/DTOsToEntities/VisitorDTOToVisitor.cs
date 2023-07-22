using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public static class VisitorDTOToVisitor
{
    public static Visitor Convert(VisitorDTO visitorDto)
    {
        var entity = new Visitor
        {
            BirthDate = visitorDto.BirthDate,
            City = visitorDto.City,
            DateIssue = visitorDto.DateIssue,
            FatherName = visitorDto.FatherName,
            FirstName = visitorDto.FirstName,
            Gender = visitorDto.Gender,
            Id = visitorDto.Id,
            LastName = visitorDto.LastName,
            Nationality = visitorDto.Nationality,
            PhotoBase64 = visitorDto.PhotoBase64,
            PassportNumber = visitorDto.PassportNumber,
            PassportSeries = visitorDto.PassportSeries
        };
        return entity;
    }
}
