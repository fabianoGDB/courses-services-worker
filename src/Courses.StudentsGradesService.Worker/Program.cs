using Courses.StudentsGradesService.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddHostedService<WorkerDemo>();
    })
    .Build();

await host.RunAsync();
