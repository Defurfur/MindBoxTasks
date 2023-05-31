using AreaCalculatorLibrary.Abstractions;
using AreaCalculatorDemo;
using AreaCalculatorLibrary;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddHostedService<CalculationWithCheckWorker>(); // Uncomment and comment the next line of code to try this version
        services.AddHostedService<SimpleCalculationWorker>();
        services.AddSingleton<IAreaCalculator, AreaCalculator>();
    })
    .Build();

host.Run();
