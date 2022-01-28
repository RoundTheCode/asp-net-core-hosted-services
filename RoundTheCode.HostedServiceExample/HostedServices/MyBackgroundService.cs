namespace RoundTheCode.HostedServiceExample.HostedServices
{
    public class MyBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.CompletedTask;
        }
    }
}
