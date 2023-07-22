using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;

namespace Data.BLL.Services;

public class OperatorService
{
    private readonly OperatorRepository _operatorRepository;

    public OperatorService(OperatorRepository operatorRepository)
    {
        _operatorRepository = operatorRepository;
    }

    public async Task AddOperator(OperatorDTO operatorDto)
    {
        var entity = OperatorDTOToOperator.Convert(operatorDto);
        await _operatorRepository.AddOperator(entity);
    }

    public async Task EditOperator(OperatorDTO operatorDto)
    {
        var entity = OperatorDTOToOperator.Convert(operatorDto);
        await _operatorRepository.EditOperator(entity);
    }

    public async Task RemoveOperator(OperatorDTO operatorDto)
    {
        var entity = OperatorDTOToOperator.Convert(operatorDto);
        await _operatorRepository.RemoveOperator(entity);
    }

    public async Task<List<Operator>> GetOperators()
    {
        return await _operatorRepository.GetOperators();
    }
}