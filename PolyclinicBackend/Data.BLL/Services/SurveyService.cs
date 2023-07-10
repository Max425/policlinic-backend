using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Service
{
    public class SurveyService
    {
        private readonly SurveyRepository _surveyRepository;

        public SurveyService(SurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task AddSurvey(SurveyDTO surveyDTO)
        {
            var entity = SurveyDTOToSurvey.Convert(surveyDTO);
            await _surveyRepository.AddSurvey(entity);
        }

        public async Task EditSurvey(SurveyDTO surveyDTO)
        {
            var entity = SurveyDTOToSurvey.Convert(surveyDTO);
            await _surveyRepository.EditSurvey(entity);
        }

        public async Task RemoveSurvey(SurveyDTO surveyDTO)
        {
            var entity = SurveyDTOToSurvey.Convert(surveyDTO);
            await _surveyRepository.RemoveSurvey(entity);
        }

        public async Task<List<Survey>> GetSurveys()
        {
            return await _surveyRepository.GetSurveys();
        }
    }
}
