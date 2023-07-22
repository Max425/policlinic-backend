using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public static class SurveyDTOToSurvey
{
    public static Survey Convert(SurveyDTO surveyDto)
    {
        var entity = new Survey
        {
            Id = surveyDto.Id,
            Price = surveyDto.Price,
            Title = surveyDto.Title
        };
        return entity;
    }
}
