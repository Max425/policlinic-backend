using Data.BLL.DTO;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Converters.EntitiesToDTOs
{
    public class SurveyToSurveyDTO
    {
        public static SurveyDTO Convert(Survey survey)
        {
            var DTO = new SurveyDTO
            {
                Id = survey.Id,
                Price = survey.Price,
                Title = survey.Title,
            };
            return DTO;
        }
    }
}
