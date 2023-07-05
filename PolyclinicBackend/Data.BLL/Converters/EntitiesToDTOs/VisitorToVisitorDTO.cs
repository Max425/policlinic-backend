using Data.BLL.DTO;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Converters.EntitiesToDTOs
{
    public class VisitorToVisitorDTO
    {
        public static VisitorDTO Convert(Visitor visitor)
        {
            var DTO = new VisitorDTO
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
                PassportNumber = visitor.PassportNumber,
                PassportSeries = visitor.PassportSeries,
            };
            return DTO;
        }
    }
}
