using RoundTheCode.HostedServiceExample.Services;

namespace RoundTheCode.HostedServiceExample.HostedServices
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly IMySingletonService _mySingletonService;
        private readonly IMyTransientService _myTransientService;
        private readonly IServiceProvider _serviceProvider;

        public MyBackgroundService(IMySingletonService mySingletonService, IMyTransientService myTransientService, IServiceProvider serviceProvider)
        {
            _mySingletonService = mySingletonService;
            _myTransientService = myTransientService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IMyScopedService>();

                    Console.WriteLine(string.Format("{0} - {1}", "MyBackgroundService", DateTime.UtcNow.ToString("HH:mm:ss")));
                    await Task.Delay(new TimeSpan(0, 0, 1));
                }
            }
        }
    }
}
