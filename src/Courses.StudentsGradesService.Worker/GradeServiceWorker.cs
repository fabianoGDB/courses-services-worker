using System.Reflection.Metadata;
using Courses.StudentsGradesService.Application.Interfaces;
using Courses.StudentsGradesService.Domain.Notification;
using Courses.StudentsGradesService.Domain.Services;
using Courses.StudentsGradesService.MessageBus.AWS.Client;
using static Courses.StudentsGradesService.Domain.Utils.Constants;

namespace Courses.StudentsGradesService.Worker;

public class GradeServiceWorker : BackgroundService
{
    private readonly ILogger<GradeServiceWorker> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public GradeServiceWorker(ILogger<GradeServiceWorker> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(ApplicationsMessages.STARTING_SERVICE);
            using var scope = _serviceScopeFactory.CreateScope();
            var studentGradeServiceApp = scope.ServiceProvider.GetService<IStudentGradeApplicationService>();
            var messageClient = scope.ServiceProvider.GetService<IFakeStudentGradeSubmitClient>();
            var notificationContext = scope.ServiceProvider.GetService<ContextNotification>();

            var message = await messageClient.GetMessageAsync();

            if (notificationContext.HasNotifications)
            {
                _logger.LogError(notificationContext.ToJson());
                continue;
            }

            if (message is null)
            {
                _logger.LogInformation(ApplicationsMessages.NO_MESSAGES_IN_QUEUE);
                continue;
            }

            await studentGradeServiceApp.ProcessStudentGradeSubmitAsync(message.MessageBody);
        }
    }
}
