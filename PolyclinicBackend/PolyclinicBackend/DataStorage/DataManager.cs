using Data.BLL.DTO;
using Microsoft.AspNetCore.SignalR;
using PolyclinicBackend.HubConfig;

namespace PolyclinicBackend.DataStorage
{
    public static class DataManager
    {
        private static readonly List<ConflictDTO>? _data = new();
        private static IHubContext<ConflictHub>? _hubContext;

        public static void InitializeHubContext(IHubContext<ConflictHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public static List<ConflictDTO> GetAll()
        {
            return _data;
        }

        public static void Add(ConflictDTO conflict)
        {
            _data.Add(conflict);
            _hubContext?.Clients.All.SendAsync("transferdata", DataManager.GetAll());
        }

        public static void Delete(int id)
        {
            _data.RemoveAll(conflict => conflict.Id == id);
        }        
    }
}
