using Hangfire;

namespace HangFireJobs
{
    public class RentalService
    {
        private readonly IServiceProvider _provider;

        public RentalService(IServiceProvider provider)
        {
            _provider = provider;
        }

        [AutomaticRetry(Attempts = 3, DelaysInSeconds = new[] { 10, 20, 30 })]
        [DisableConcurrentExecution(timeoutInSeconds: 60)]
        public void ProcessRentalJobs()
        {
            using var scope = _provider.CreateScope();
            var dbcontext = scope.ServiceProvider.GetRequiredService<DbContext>();
            dbcontext.DeleteMovies();
            Console.WriteLine("1");
        }
    }
}
