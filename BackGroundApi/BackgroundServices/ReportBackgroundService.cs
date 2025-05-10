
using BackGroundApi.Data;

namespace BackGroundApi.BackgroundServices
{
    public class ReportBackgroundService : BackgroundService
    {
        private readonly ILogger<ReportBackgroundService> _logger;

        public ReportBackgroundService(ILogger<ReportBackgroundService> logger)
        {
            _logger = logger;
        }

        Timer? _timer;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(StartWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void StartWork(object? state)
        {
            bool isRunning = false;
            Task.Run(async () =>
            {
                try
                {
                    if (isRunning)
                    {
                        return;
                    }
                    isRunning = true;
                    await DoWorkAsync();
                    isRunning = false;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in ReportBackgroundService");
                }
            });
        }

        private async Task DoWorkAsync()
        {
            await Task.Delay(5000);
            _logger.LogError("Report started" + DateTime.Now);
            await Task.Delay(2000);
            Database.Reports.Add(new Report
            {
                Name = "Report 1",
                UpdatedAt = DateTime.UtcNow,
                Information = "Report 1 information"
            });
            _logger.LogError("Report finished" + DateTime.Now);
        }
    }
}
