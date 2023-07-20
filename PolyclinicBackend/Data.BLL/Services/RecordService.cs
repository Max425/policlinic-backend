using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.Converters.EntitiesToDTOs;
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
    public class RecordService
    {
        private readonly RecordRepository _recordRepository;

        public RecordService(RecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task AddRecord(RecordDTO RecordDTO)
        {
            var entity = RecordDTOToRecord.Convert(RecordDTO);
            await _recordRepository.AddRecord(entity);
        }

        public async Task EditRecord(RecordDTO RecordDTO)
        {
            var entity = RecordDTOToRecord.Convert(RecordDTO);
            await _recordRepository.EditRecord(entity);
        }

        public async Task RemoveRecord(RecordDTO RecordDTO)
        {
            var entity = RecordDTOToRecord.Convert(RecordDTO);
            await _recordRepository.RemoveRecord(entity);
        }

        public async Task<List<Record>> GetRecords()
        {
            return await _recordRepository.GetRecords();
        }

        public async Task<List<RecordDTO>> GetRecordsByVisitorId(int id)
        {
            List<Record> records = await _recordRepository.GetRecordsByVisitorId(id);
            List<RecordDTO> recordDTOs = records.ConvertAll(record => RecordToRecordDTO.Convert(record));
            return recordDTOs;
        }
    }
}
