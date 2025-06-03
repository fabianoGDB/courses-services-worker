namespace Courses.StudentsGradesService.Worker;

public class GradeServiceWorker : BackgroundService
{
    private readonly ILogger<GradeServiceWorker> _logger;

    public GradeServiceWorker(ILogger<GradeServiceWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
