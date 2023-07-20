using Data.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Data.BLL.Services;

public class BackgroundWorkerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public BackgroundWorkerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
/*        int batchSize = 100000;  // Размер пачки данных
        int skipCount = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var visitorGeneratedRepo = scope.ServiceProvider.GetRequiredService<VisitorGeneratedRepository>();

                try
                {
                    // Получить данные из сгенерированной БД
                    var visitors = await visitorGeneratedRepo.GetVisitorGenerated(batchSize, skipCount);

                    // TODO: дергать какой-то метод для добавления
                    //
                    //
                    skipCount += batchSize;
                }
                catch (Exception ex)
                {
                    // Обработка ошибок
                }
            }

            // Задержка на 5 минут перед следующей итерацией
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }*/
    }
}
