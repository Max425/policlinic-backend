using Data.BLL.Converters.DTOsToEntities;
using Data.BLL.Converters.EntitiesToDTOs;
using Data.BLL.DTO;
using Data.DAL.Entities;
using Data.DAL.Repositories;

namespace Data.BLL.Services;

public class RecordService
{
    private readonly RecordRepository _recordRepository;

    public RecordService(RecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public async Task AddRecord(RecordDTO recordDto)
    {
        var entity = RecordDTOToRecord.Convert(recordDto);
        await _recordRepository.AddRecord(entity);
    }

    public async Task EditRecord(RecordDTO recordDto)
    {
        var entity = RecordDTOToRecord.Convert(recordDto);
        await _recordRepository.EditRecord(entity);
    }

    public async Task RemoveRecord(RecordDTO recordDto)
    {
        var entity = RecordDTOToRecord.Convert(recordDto);
        await _recordRepository.RemoveRecord(entity);
    }

    public async Task<List<Record>> GetRecords()
    {
        return await _recordRepository.GetRecords();
    }

    public async Task<List<RecordDTO>> GetRecordsByVisitorId(int id)
    {
        var records = await _recordRepository.GetRecordsByVisitorId(id);
        var recordDtOs = records.ConvertAll(RecordToRecordDTO.Convert);
        return recordDtOs;
    }
}