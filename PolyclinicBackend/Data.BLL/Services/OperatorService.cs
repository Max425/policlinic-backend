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
    public class OperatorService
    {
        private readonly OperatorRepository _operatorRepository;

        public OperatorService(OperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public async Task AddOperator(OperatorDTO operatorDTO)
        {
            var entity = OperatorDTOToOperator.Convert(operatorDTO);
            await _operatorRepository.AddOperator(entity);
        }

        public async Task EditOperator(OperatorDTO operatorDTO)
        {
            var entity = OperatorDTOToOperator.Convert(operatorDTO);
            await _operatorRepository.EditOperator(entity);
        }

        public async Task RemoveOperator(OperatorDTO operatorDTO)
        {
            var entity = OperatorDTOToOperator.Convert(operatorDTO);
            await _operatorRepository.RemoveOperator(entity);
        }

        public async Task<List<Operator>> GetOperators()
        {
            return await _operatorRepository.GetOperators();
        }
    }
}
