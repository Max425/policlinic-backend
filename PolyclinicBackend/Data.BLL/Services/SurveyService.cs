using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;

namespace Data.BLL.Services;

public class SurveyService
{
    private readonly SurveyRepository _surveyRepository;

    public SurveyService(SurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task AddSurvey(SurveyDTO surveyDto)
    {
        var entity = SurveyDTOToSurvey.Convert(surveyDto);
        await _surveyRepository.AddSurvey(entity);
    }

    public async Task EditSurvey(SurveyDTO surveyDto)
    {
        var entity = SurveyDTOToSurvey.Convert(surveyDto);
        await _surveyRepository.EditSurvey(entity);
    }

    public async Task RemoveSurvey(SurveyDTO surveyDto)
    {
        var entity = SurveyDTOToSurvey.Convert(surveyDto);
        await _surveyRepository.RemoveSurvey(entity);
    }

    public async Task<List<Survey>> GetSurveys()
    {
        return await _surveyRepository.GetSurveys();
    }

    public async Task<Survey> GetSurveyById(int id)
    {
        return await _surveyRepository.GetSurveyById(id);
    }
}