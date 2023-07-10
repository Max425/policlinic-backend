using Data.BLL.DTO;
using Data.BLL.Facade;
using Data.BLL.Service;
using Data.DAL.Entities;
using Data.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace PolyclinicBackend.Controllers;

[Route("[controller]")]
[ApiExplorerSettings(GroupName = "Polyclinic")]
public class InteractionsWithDBController : Controller
{
    private readonly Facade _facade;

    public InteractionsWithDBController(Facade facade)
    {
        _facade = facade;
    }

    [HttpGet("GetVisitors")]
    public async Task<IActionResult> GetVisitors()
    {
        IActionResult res;
        try
        {
            res = Ok(await _facade.VisitorService.GetVisitors());
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpGet("GetRecord")]
    public async Task<IActionResult> GetRecord()
    {
        IActionResult res;
        try
        {
            res = Ok(await _facade.RecordService.GetRecords());
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpGet("GetSurvey")]
    public async Task<IActionResult> GetSurvey()
    {
        IActionResult res;
        try
        {
            res = Ok(await _facade.SurveyService.GetSurveys());
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpGet("GetDoctor")]
    public async Task<IActionResult> GetDoctors()
    {
        IActionResult res;
        try
        {
            res = Ok(await _facade.DoctorService.GetDoctors());
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpGet("GetCredentials")]
    public async Task<IActionResult> GetCredentials()
    {
        IActionResult res;
        try
        {
            res = Ok(await _facade.CredentialService.GetCredentials());
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpGet("GetOperator")]
    public async Task<IActionResult> GetOperators()
    {
        IActionResult res;
        try
        {
            res = Ok(await _facade.OperatorService.GetOperators());
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPost("CreateVisitor")]
    public async Task<IActionResult> CreateVisitor(string firstName, string lastName, string fatherName, string city, string gender,
        DateTime birthDate, string nationality, int passportSeries, string photoBase64, int passportNumber, DateTime dateIssue)
    {
        IActionResult res;
        try
        {
            await _facade.VisitorService.AddVisitor(new VisitorDTO { FirstName = firstName, LastName = lastName, FatherName = fatherName, City = city, Gender = gender, BirthDate = birthDate, DateIssue = dateIssue, Nationality = nationality, PassportNumber = passportNumber, PassportSeries = passportSeries, PhotoBase64 = photoBase64 });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPost("CreateRecord")]
    public async Task<IActionResult> CreateRecord(DateTime date, int visId, int surveyId, int operatorId)
    {
        IActionResult res;
        try
        {
            await _facade.RecordService.AddRecord(new RecordDTO { Date = date, VisitorId = visId, SurveyId = surveyId, OperatorId = operatorId });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPost("CreateSurvey")]
    public async Task<IActionResult> CreateSurvey(string title, int price)
    {
        IActionResult res;
        try
        {
            await _facade.SurveyService.AddSurvey(new SurveyDTO { Title = title, Price = price });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPost("CreateDoctor")]
    public async Task<IActionResult> CreateDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        IActionResult res;
        try
        {
            await _facade.DoctorService.AddDoctor(new DoctorDTO { FullName = fullName, CabinetNumber = cabinetNumber, SurveyId = surveyId });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPost("CreateCredential")]
    public async Task<IActionResult> CreateCredential(string login, string password, int operatorId)
    {
        IActionResult res;
        try
        {
            await _facade.CredentialService.AddCredential(new CredentialDTO { Login = login, Password = password, OperatorId = operatorId });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPost("CreateOperator")]
    public async Task<IActionResult> CreateOperator(string firstName, string lastName, string fatherName)
    {
        IActionResult res;
        try
        {
            await _facade.OperatorService.AddOperator(new OperatorDTO { FirstName = firstName, LastName = lastName, FatherName = fatherName });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPut("EditVisitor")]
    public async Task<IActionResult> EditVisitor(string firstName, string lastName, string fatherName, string city, string gender,
        DateTime birthDate, string nationality, int passportSeries, string photoBase64, int passportNumber, DateTime dateIssue)
    {
        IActionResult res;
        try
        {
            await _facade.VisitorService.EditVisitor(new VisitorDTO { FirstName = firstName, LastName = lastName, FatherName = fatherName, City = city, Gender = gender, BirthDate = birthDate, DateIssue = dateIssue, Nationality = nationality, PassportNumber = passportNumber, PassportSeries = passportSeries, PhotoBase64 = photoBase64 });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPut("EditRecord")]
    public async Task<IActionResult> EditRecord(DateTime date, int visId, int surveyId, int operatorId)
    {
        IActionResult res;
        try
        {
            await _facade.RecordService.EditRecord(new RecordDTO { Date = date, VisitorId = visId, SurveyId = surveyId, OperatorId = operatorId }); res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPut("EditSurvey")]
    public async Task<IActionResult> EditSurvey(string title, int price)
    {
        IActionResult res;
        try
        {
            await _facade.SurveyService.EditSurvey(new SurveyDTO { Title = title, Price = price });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPut("EditDoctor")]
    public async Task<IActionResult> EditDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        IActionResult res;
        try
        {
            await _facade.DoctorService.EditDoctor(new DoctorDTO { FullName = fullName, CabinetNumber = cabinetNumber, SurveyId = surveyId });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPut("EditCredential")]
    public async Task<IActionResult> EditCredetial(string login, string password, int operatorId)
    {
        IActionResult res;
        try
        {
            await _facade.CredentialService.EditCredential(new CredentialDTO { Login = login, Password = password, OperatorId = operatorId });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpPut("EditOperator")]
    public async Task<IActionResult> EditOperator(string firstName, string lastName, string fatherName)
    {
        IActionResult res;
        try
        {
            await _facade.OperatorService.EditOperator(new OperatorDTO { FirstName = firstName, LastName = lastName, FatherName = fatherName });
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
            await _facade.VisitorService.Remove(new VisitorDTO { PassportSeries = passportSeries, PassportNumber = passportNumber });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpDelete("RemoveRecord")]
    public async Task<IActionResult> RemoveRecord(DateTime dateTime)
    {
        IActionResult res;
        try
        {
            await _facade.RecordService.RemoveRecord(new RecordDTO { Date = dateTime }); res = Ok();
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
            await _facade.SurveyService.RemoveSurvey(new SurveyDTO { Title = title });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpDelete("RemoveDoctor")]
    public async Task<IActionResult> RemoveDoctor(string fullName, int cabinetNumber, int surveyId)
    {
        IActionResult res;
        try
        {
            await _facade.DoctorService.RemoveDoctor(new DoctorDTO { FullName = fullName, CabinetNumber = cabinetNumber, SurveyId = surveyId });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpDelete("RemoveCredential")]
    public async Task<IActionResult> RemoveCredential(string login)
    {
        IActionResult res;
        try
        {
            await _facade.CredentialService.RemoveCredential(new CredentialDTO { Login = login });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }

    [HttpDelete("RemoveOperator")]
    public async Task<IActionResult> RemoveOperator(string firstName, string fatherName, string lastName)
    {
        IActionResult res;
        try
        {
            await _facade.OperatorService.RemoveOperator(new OperatorDTO { FirstName = firstName, LastName = lastName, FatherName = fatherName });
            res = Ok();
        }
        catch (Exception ex) { res = BadRequest(ex.Message); }
        return res;
    }
}
