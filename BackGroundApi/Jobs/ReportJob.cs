namespace BackGroundApi.Jobs
{
    public class ReportJob
    {
        private readonly ILogger<ReportJob> _logger;

        public ReportJob(ILogger<ReportJob> logger)
        {
            _logger = logger;
        }

        public bool InProgress { get; set; }

        public async Task Excecute(CancellationToken token)
        {
            if (InProgress)
            {
                _logger.LogError("Report job already in progress");
                return;
            }

            InProgress = true;
            _logger.LogError("Report generation started");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            _logger.LogError("Report Loading");
       
            _logger.LogError("Report generated");
            InProgress = false;
        }
    }
}
