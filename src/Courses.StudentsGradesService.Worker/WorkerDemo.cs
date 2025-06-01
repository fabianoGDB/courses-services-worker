using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.StudentsGradesService.Worker
{
    public class WorkerDemo : IHostedService, IDisposable
    {
        private readonly ILogger<WorkerDemo> _logger;
        private readonly HttpClient _httpClient;
        private Timer? _timer;
        public WorkerDemo(ILogger<WorkerDemo> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service is running.");
            _timer = new Timer(IsSiteStatusOn, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private async void IsSiteStatusOn(object? state)
        {
            var response = await _httpClient.GetAsync("https://www.google.com.br");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Site Ok with Status Code: {response.StatusCode}");
            }
            else
            {
                _logger.LogInformation($"Site not Ok with Status Code: {response.StatusCode}");
            }
        }

        // private void DoWork(object? state)
        // {
        //     int count = Interlocked.Increment(ref _executionCount);

        //     _logger.LogInformation(
        //         "Service is working, execution count: {Count:#,0}",
        //         count);
        // }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}