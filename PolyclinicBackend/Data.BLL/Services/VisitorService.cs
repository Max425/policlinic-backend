using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;
using Data.DAL.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BLL.Service
{
    public class VisitorService
    {
        private readonly VisitorRepository _visitorRepository;
        public VisitorService(VisitorRepository visitorRepository)
        {
            _visitorRepository = visitorRepository;
        }

        public async Task AddVisitor(VisitorDTO visitorDTO)
        {
            var entity = VisitorDTOToVisitor.Convert(visitorDTO);
            await _visitorRepository.AddVisitor(entity);
        }

        public async Task EditVisitor(VisitorDTO visitorDTO)
        {
            var entity = VisitorDTOToVisitor.Convert(visitorDTO);
            await _visitorRepository.EditVisitor(entity);
        }

        public async Task Remove(VisitorDTO visitorDTO)
        {
            var entity = VisitorDTOToVisitor.Convert(visitorDTO);
            await _visitorRepository.Remove(entity);
        }

        public async Task<List<Visitor>> GetVisitors()
        {
            return await _visitorRepository.GetVisitors();
        }

        public async Task<ValidationEnumerator> CheckVisitorForExisting(VisitorDTO visitorDTO)
        {
            var entity = VisitorDTOToVisitor.Convert(visitorDTO);
            return await _visitorRepository.CheckVisitorForExisting(entity);
        }
    }
}
