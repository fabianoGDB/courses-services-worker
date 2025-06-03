using Courses.StudentsGradesService.IOC;
using Courses.StudentsGradesService.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.ConfigureDependencyInjection();
        services.AddHostedService<GradeServiceWorker>();
        //services.AddHostedService<WorkerDemo>();
    })
    .Build();

await host.RunAsync();
