using Data.BLL.DTO;
using Data.BLL.Facade;
using Data.BLL.Converters.EntitiesToDTOs;

namespace PolyclinicBackend.DataStorage
{
    public static class DataManager
    {
        private static readonly List<ConflictDTO>? _data = new();

        public static List<ConflictDTO> GetAll()
        {
            return _data;
        }

        public static void Add(ConflictDTO conflict)
        {
            _data.Add(conflict);
        }

        public static void Delete(int id)
        {
            _data.RemoveAll(conflict => conflict.Id == id);
        }        
    }
}
