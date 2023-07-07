using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public class SurveyDTOToSurvey
{
    public static Survey Convert(SurveyDTO surveyDTO)
    {
        var entity = new Survey
        {
            Id = surveyDTO.Id,
            Price = surveyDTO.Price,
            Title = surveyDTO.Title
        };
        return entity;
    }
}
