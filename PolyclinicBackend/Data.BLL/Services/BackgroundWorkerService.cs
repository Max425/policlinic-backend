using Data.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VisitorGenerated.Repositories;

namespace Data.BLL.Services;

public class BackgroundWorkerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public BackgroundWorkerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _ = ExecuteAsync(new CancellationToken());
    }

    protected sealed override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int batchSize = 100;
        var skipCount = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var visitorGeneratedRepo = scope.ServiceProvider.GetRequiredService<VisitorGeneratedRepository>();
                var visitorRepo = scope.ServiceProvider.GetRequiredService<VisitorRepository>();

                try
                {
                    var visitors = await visitorGeneratedRepo.GetVisitorGenerated(batchSize, skipCount);

                    // TODO: дергать метод для добавления
                    foreach (var visitor in visitors)
                    {
                        await visitorRepo.AddVisitor(visitor);
                    }

                    skipCount += batchSize;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}