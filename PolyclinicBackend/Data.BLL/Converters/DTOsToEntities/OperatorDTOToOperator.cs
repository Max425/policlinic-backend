using Data.BLL.DTO;
using Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Converters.DTOsToEntities
{
    public class OperatorDTOToOperator
    {
        public static Operator Convert(OperatorDTO operatorDTO)
        {
            var entity = new Operator
            {
                Id = operatorDTO.Id,
                FirstName = operatorDTO.FirstName,
                FatherName = operatorDTO.FatherName,
                LastName = operatorDTO.LastName
            };
            return entity;
        }
    }
}
