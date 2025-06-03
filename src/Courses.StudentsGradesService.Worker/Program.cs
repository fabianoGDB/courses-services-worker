using Courses.StudentsGradesService.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<GradeServiceWorker>();
        services.AddHostedService<WorkerDemo>();
    })
    .Build();

await host.RunAsync();
