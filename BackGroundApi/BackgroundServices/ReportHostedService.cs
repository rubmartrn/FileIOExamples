
namespace BackGroundApi.BackgroundServices
{
    public class ReportHostedService : IHostedService
    {
        public ReportHostedService(ILogger<ReportHostedService> logger)
        {
            _logger = logger;
        }

        Timer? t;
        private readonly ILogger<ReportHostedService> _logger;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            t = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            _logger.LogError("Report generation started");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            t.Dispose();
            return Task.CompletedTask;
        }
    }
}
