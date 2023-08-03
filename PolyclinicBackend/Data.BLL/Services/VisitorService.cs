using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;
using Data.DAL.Validator;

namespace Data.BLL.Services;

public class VisitorService
{
    private readonly VisitorRepository _visitorRepository;

    public VisitorService(VisitorRepository visitorRepository)
    {
        _visitorRepository = visitorRepository;
    }

    public async Task AddVisitor(VisitorDTO visitorDto)
    {
        var entity = VisitorDTOToVisitor.Convert(visitorDto);
        await _visitorRepository.AddVisitor(entity);
    }

    public async Task EditVisitor(VisitorDTO visitorDto)
    {
        var entity = VisitorDTOToVisitor.Convert(visitorDto);
        await _visitorRepository.EditVisitor(entity);
    }

    public async Task Remove(VisitorDTO visitorDto)
    {
        var entity = VisitorDTOToVisitor.Convert(visitorDto);
        await _visitorRepository.Remove(entity);
    }

    public async Task<List<Visitor>> GetVisitors()
    {
        return await _visitorRepository.GetVisitors();
    }

    public async Task<ValidationEnumerator> CheckVisitorForExisting(VisitorDTO visitorDto)
    {
        var entity = VisitorDTOToVisitor.Convert(visitorDto);
        return await _visitorRepository.CheckVisitorForExisting(entity);
    }
}