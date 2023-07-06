using Data.DAL.Entities;
using Data.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PolyclinicBackend.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "Polyclinic")]
    public class InteractionsWithDBController : Controller
    {
        private readonly VisitorRepository _visitorRepository;
        private readonly RecordRepository _recordRepository;
        private readonly SurveyRepository _surveyRepository;
        public InteractionsWithDBController(VisitorRepository visitorRepository, RecordRepository recordRepository, SurveyRepository surveyRepository)
        {
            _visitorRepository = visitorRepository;
            _recordRepository = recordRepository;
            _surveyRepository = surveyRepository;
        }

        [HttpGet("AddVisitor")]
        public async Task<IActionResult> AddVisitor(string firstName, string lastName, string fatherName, string city, string gender,
            DateTime birthDate, string nationality, int passportSeries, int passportNumber, DateTime dateIssue)
        {
            IActionResult res;
            try
            {
                await _visitorRepository.AddVisitor(firstName, lastName, fatherName, city, gender,
            birthDate, nationality, passportSeries, passportNumber, dateIssue);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpGet("AddRecord")]
        public async Task<IActionResult> AddRecord(DateTime date, int visId, int surveyId)
        {
            IActionResult res;
            try
            {
                await _recordRepository.AddRecord(date, visId, surveyId);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpGet("AddSurvey")]
        public async Task<IActionResult> AddSurvey(string title, int price)
        {
            IActionResult res;
            try
            {
                await _surveyRepository.AddSurvey(title, price);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpPatch("EditVisitor")]
        public async Task<IActionResult> EditVisitor(string firstName, string lastName, string fatherName, string city, string gender,
            DateTime birthDate, string nationality, int passportSeries, int passportNumber, DateTime dateIssue)
        {
            IActionResult res;
            try
            {
                await _visitorRepository.EditVisitor(firstName, lastName, fatherName, city, gender,
                birthDate, nationality, passportSeries, passportNumber, dateIssue);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpPatch("EditRecord")]
        public async Task<IActionResult> EditRecord(DateTime date, int visId, int surveyId)
        {
            IActionResult res;
            try
            {
                await _recordRepository.EditRecord(date, visId, surveyId);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpPatch("EditSurvey")]
        public async Task<IActionResult> EditSurvey(string title, int price)
        {
            IActionResult res;
            try
            {
                await _surveyRepository.EditSurvey(title, price);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpDelete("RemoveVisitor")]
        public async Task<IActionResult> RemoveVisitor(int passportSeries, int passportNumber)
        {
            IActionResult res;
            try
            {
                await _visitorRepository.Remove(passportSeries, passportNumber);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpDelete("RemoveRecord")]
        public async Task<IActionResult> RemoveRecord(DateTime dateTime, int visitorId, int surveyId)
        {
            IActionResult res;
            try
            {
                await _recordRepository.RemoveRecord(dateTime, visitorId, surveyId);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }

        [HttpDelete("RemoveSurvey")]
        public async Task<IActionResult> RemoveSurvey(string title)
        {
            IActionResult res;
            try
            {
                await _surveyRepository.RemoveSurvey(title);
                res = Ok();
            }
            catch (Exception ex) { res = BadRequest(ex.Message); }
            return res;
        }
    }
}
