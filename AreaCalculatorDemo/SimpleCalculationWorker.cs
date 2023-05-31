using AreaCalculatorLibrary.Abstractions;
using AreaCalculatorLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace AreaCalculatorDemo
{
    public class SimpleCalculationWorker : BackgroundService
    {
        private readonly ILogger<SimpleCalculationWorker> _logger;
        private readonly IAreaCalculator _areaCalculator;
        private readonly Random _rand = new();

        public SimpleCalculationWorker(ILogger<SimpleCalculationWorker> logger, IAreaCalculator areaCalculator)
        {
            _logger = logger;
            _areaCalculator = areaCalculator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                IShape shape = _rand.NextDouble() switch
                {
                    < 0.33d => new Circle(_rand.Next(40)),
                    > 0.66d => new Triangle(_rand.Next(1, 10), _rand.Next(1, 10), _rand.Next(1, 10)),
                    _ => new Rectangle(_rand.Next(1, 10), _rand.Next(1, 10))
                };

                var result = _areaCalculator.Calculate(shape);

                _logger.LogInformation(
                    "This is a {shape}. Result area is {result}",
                    shape.GetType().Name,
                    result); 

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}