namespace BackGroundApi.Services
{
    public class ReportService
    {
        private readonly ILogger<ReportService> _logger;

        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
        }

        public bool _inProgress = false;

        public async Task CreateAndSendReport(CancellationToken token)
        {
            if (_inProgress)
            {
                _logger.LogError("Report job already in progress");
                return;
            }

            _inProgress = true;
            _logger.LogError("Report generation started");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            _inProgress = false;
        }
    }
}
