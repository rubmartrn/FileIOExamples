using BackGroundApi.Enums;

namespace BackGroundApi.Jobs
{
    public class ReportJob
    {
        private readonly ILogger<ReportJob> _logger;

        public ReportJob(ILogger<ReportJob> logger)
        {
            _logger = logger;
        }

        public ProgressEnum Progress { get; set; } = ProgressEnum.Ready;

        public async Task Excecute(CancellationToken token)
        {
            if (Progress != ProgressEnum.Ready)
            {
                _logger.LogError("Report job already in progress");
                return;
            }

            Progress = ProgressEnum.Started;
            _logger.LogError("Report generation started");
            await Task.Delay(5000, token);
            Progress = ProgressEnum.Step1;

            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);
            Progress = ProgressEnum.Step2;

            _logger.LogError("Report Loading");
            await Task.Delay(5000, token);

            Progress = ProgressEnum.Step3;
            _logger.LogError("Report Loading");

            _logger.LogError("Report generated");
            Progress = ProgressEnum.Ready;
        }
    }
}
