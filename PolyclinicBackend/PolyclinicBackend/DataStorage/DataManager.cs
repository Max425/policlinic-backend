using Data.BLL.DTO;
using Microsoft.AspNetCore.SignalR;
using PolyclinicBackend.HubConfig;

namespace PolyclinicBackend.DataStorage;

public static class DataManager
{
    private static readonly List<ConflictDTO>? Data = new();
    private static IHubContext<ConflictHub>? _hubContext;

    public static void InitializeHubContext(IHubContext<ConflictHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public static List<ConflictDTO>? GetAll()
    {
        return Data;
    }

    public static void Add(ConflictDTO conflict)
    {
        Data?.Add(conflict);
        _hubContext?.Clients.All.SendAsync("transferdata", GetAll());
    }

    public static void Delete(int id)
    {
        Data?.RemoveAll(conflict => conflict.Id == id);
    }
}