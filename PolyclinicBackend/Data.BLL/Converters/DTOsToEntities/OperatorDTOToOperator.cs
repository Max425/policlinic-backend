using Data.BLL.DTO;
using Data.DAL.Entities;

namespace Data.BLL.Converters.DTOsToEntities;

public static class OperatorDTOToOperator
{
    public static Operator Convert(OperatorDTO operatorDto)
    {
        var entity = new Operator
        {
            Id = operatorDto.Id,
            FirstName = operatorDto.FirstName,
            FatherName = operatorDto.FatherName,
            LastName = operatorDto.LastName
        };
        return entity;
    }
}