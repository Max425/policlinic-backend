using Data.BLL.DTO;
using Microsoft.AspNetCore.SignalR;
using PolyclinicBackend.DataStorage;

namespace PolyclinicBackend.HubConfig
{
    public class ConflictHub : Hub
    {
        public async Task Send(ConflictDTO data)
        {
            DataManager.Delete(data.Id);
            await Clients.All.SendAsync("transferdata", DataManager.GetAll());
        }
    }
}
