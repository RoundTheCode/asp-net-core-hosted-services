namespace RoundTheCode.HostedServiceExample.HostedServices
{
    public class MyBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine(string.Format("{0} - {1}", "MyBackgroundService", DateTime.UtcNow.ToString("HH:mm:ss")));
                await Task.Delay(new TimeSpan(0, 0, 1));
            }
        }
    }
}
