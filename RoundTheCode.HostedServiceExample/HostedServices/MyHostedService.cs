namespace RoundTheCode.HostedServiceExample.HostedServices
{
    public class MyHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine(string.Format("{0} - {1}", "MyHostedService", DateTime.UtcNow.ToString("HH:mm:ss")));
                    await Task.Delay(new TimeSpan(0, 0, 1));
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
