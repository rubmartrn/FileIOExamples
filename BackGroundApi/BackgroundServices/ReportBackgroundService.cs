
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
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
