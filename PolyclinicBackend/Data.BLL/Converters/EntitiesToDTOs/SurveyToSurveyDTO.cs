using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.EntitiesToDTOs;

public static class SurveyToSurveyDTO
{
    public static SurveyDTO Convert(Survey survey)
    {
        var dto = new SurveyDTO
        {
            Id = survey.Id,
            Price = survey.Price,
            Title = survey.Title,
        };
        return dto;
    }
}
