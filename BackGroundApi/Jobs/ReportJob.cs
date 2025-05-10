namespace BackGroundApi.Jobs
{
    public class ReportJob
    {
        private readonly ILogger<ReportJob> _logger;

        public ReportJob(ILogger<ReportJob> logger)
        {
            _logger = logger;
        }

        public async Task Excecute(CancellationToken token)
        {
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

            _logger.LogError("Report generated");
        }
    }
}
